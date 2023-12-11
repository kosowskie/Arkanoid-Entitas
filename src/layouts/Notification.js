import React from 'react';
import { Snackbar, styled, Alert } from '@mui/material';

const StyledSnackbar = styled(Snackbar)(({ theme }) => ({
    top: theme.spacing(9),
    '& .MuiAlert-root': {
        backgroundColor: '#f3b33d',
        color: '#000'
    },
    '& .MuiAlert-icon': {
        color: '#000'
    }
}));

export default function Notification(props) {
    const { notify, setNotify } = props;

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }
        setNotify({
            ...notify,
            isOpen: false
        });
    };

    return (
        <StyledSnackbar
            autoHideDuration={3000}
            open={notify.isOpen}
            anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
            onClose={handleClose}>
            <Alert onClose={handleClose}>
                {notify.message}
            </Alert>
        </StyledSnackbar>
    );
}
