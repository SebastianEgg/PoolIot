//@CodeCopy
using CommonBase.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnQPoolIot.WebApi.Controllers
{
	public abstract class GenericController<I, M> : ApiControllerBase, IDisposable
        where I : Contracts.IIdentifiable
        where M : Transfer.Models.IdentityModel, I, Contracts.ICopyable<I>, new()
    {
		private bool disposedValue;

		protected GenericController()
		{
		}

#if ACCOUNT_ON
		protected async Task<Contracts.Client.IControllerAccess<I>> CreateControllerAsync()
		{
			var result = Logic.Factory.Create<I>();
			var sessionToken = await GetSessionTokenAsync().ConfigureAwait(false);

			if (sessionToken.HasContent())
			{
				result.SessionToken = sessionToken;
			}
			return result;
		}
#else
		protected Task<Contracts.Client.IControllerAccess<I>> CreateControllerAsync()
		{
			return Task.Run(() => Logic.Factory.Create<I>());
		}
#endif
		protected M ToModel(I entity)
		{
			var result = new M();

			result.CopyProperties(entity);
			return result;
		}
		/// <summary>
		/// Dieser Request ergibt uns eine Anzahl wie viele Einträge sich in der dazugehörigen Tabelle befinden.
		/// </summary>
		/// <returns></returns>
		[HttpGet("/api/[controller]/Count")]
		public async Task<int> GetCountAsync()
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);

			return await ctrl.CountAsync().ConfigureAwait(false);
		}
		/// <summary>
		/// Dieser Request ergibt uns eine Anzahl wie viele Einträge sich in der dazugehörigen Tabelle befinden, wenn wir nach einem bestimmten Wort suchen.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		[HttpGet("/api/[controller]/Count/{predicate}")]
		public async Task<int> GetCountByAsync(string predicate)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);

			return await ctrl.CountByAsync(predicate).ConfigureAwait(false);
		}
		/// <summary>
		/// Dieser Request übermittelt den Wert welcher die dazugehörige Id hat
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("/api/[controller]/{id}")]
		public async Task<M> GetByIdAsync(int id)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var result = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

			return ToModel(result);
		}
		/// <summary>
		/// Dieser Request übermittelt uns alle Werte der dazugehörigen Tabelle
		/// </summary>
		/// <returns></returns>
		[HttpGet("/api/[controller]")]
		public async Task<IEnumerable<M>> GetAllAsync()
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var result = await ctrl.GetAllAsync().ConfigureAwait(false);

			return result.Select(e => ToModel(e));
		}
		/*
		public async Task<IEnumerable<M>> GetAllAsyncInFiles()
		{
			using var ctrl = Logic.Factory.Create<I>();
			var result = await ctrl.GetAllAsync().ConfigureAwait(false);

			return result.Select(e => ToModel(e));
		}
		*/
		/// <summary>
		/// Dieser Request übermittelt uns die Tabellenspalten der dazugehörigen Tabelle, welche das Suchkriterium erfüllen
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		[HttpGet("/api/[controller]/Query/{predicate}")]
		public async Task<IEnumerable<M>> QueryAllBy(string predicate)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var result = await ctrl.QueryAllAsync(predicate).ConfigureAwait(false);

			return result.Select(e => ToModel(e));
		}
		/// <summary>
		/// Dieser Request erzeugt einen neuen Datenbankeintrag in die Tabelle.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost("/api/[controller]")]
		public async Task<M> PostAsync([FromBody] M model)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var result = await ctrl.InsertAsync(model).ConfigureAwait(false);

			await ctrl.SaveChangesAsync().ConfigureAwait(false);
			return ToModel(result);
		}
		/// <summary>
		/// Dieser Request erzeugt mehrer neue Datenbankeintrag in die Tabelle. 
		/// </summary>
		/// <param name="models"></param>
		/// <returns></returns>
		[HttpPost("/api/[controller]/Array")]
		public async Task<IQueryable<M>> PostArrayAsync(IEnumerable<M> models)
		{
			var result = new List<M>();
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var entities = await ctrl.InsertAsync(models).ConfigureAwait(false);

			await ctrl.SaveChangesAsync().ConfigureAwait(false);
			result.AddRange(entities.Select(e => ToModel(e)));
			return result.AsQueryable();
		}
		/// <summary>
		/// Dieser Request verändert einen Datenbankeintrag in der Tabelle. 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPut("/api/[controller]")]
		public async Task<M> PutAsync([FromBody]M model)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var result = await ctrl.UpdateAsync(model).ConfigureAwait(false);

			await ctrl.SaveChangesAsync().ConfigureAwait(false);
			return ToModel(result);
		}
		/// <summary>
		/// Dieser Request verändert mehrere Datenbankeintrag in der Tabelle. 
		/// </summary>
		/// <param name="models"></param>
		/// <returns></returns>
		[HttpPut("/api/[controller]/Array")]
		public async Task<IQueryable<M>> PutArrayAsync(IEnumerable<M> models)
		{
			var result = new List<M>();
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);
			var entities = await ctrl.UpdateAsync(models).ConfigureAwait(false);

			await ctrl.SaveChangesAsync().ConfigureAwait(false);
			result.AddRange(entities.Select(e => ToModel(e)));
			return result.AsQueryable();
		}
		/// <summary>
		/// Dieser Request löscht einen Datenbankeintrag mit der dazugehörigen Id in der Tabelle.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("/api/[controller]/{id}")]
		public async Task DeleteAsync(int id)
		{
			using var ctrl = await CreateControllerAsync().ConfigureAwait(false);

			await ctrl.DeleteAsync(id).ConfigureAwait(false);
			await ctrl.SaveChangesAsync().ConfigureAwait(false);
		}

		#region Disposable pattern
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~GenericController()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion Disposable pattern
	}
}
