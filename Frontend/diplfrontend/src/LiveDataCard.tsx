import { Box, Paper, Typography } from '@mui/material';
import * as React from 'react';

export default function LiveDataCard() {
    return (
        <Box  sx={{p:1}}>
            <Paper sx={{p:2}}>
                <Typography>
                    Temperatur
                </Typography>
            </Paper>
            <Paper sx={{p:2}}>
                <Typography>
                    NTU
                </Typography>
            </Paper>
            <Paper sx={{p:2}}>
                <Typography>
                    Ph-Wert
                </Typography>
            </Paper>

        </Box>
    );
};
