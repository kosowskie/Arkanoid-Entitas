import React from 'react'
import { Dialog, DialogTitle, DialogContent, Typography, IconButton } from '@mui/material';
import { styled } from '@mui/material/styles';
import CloseIcon from '@mui/icons-material/Close';

const DialogWrapper = styled(Dialog)(({ theme }) => ({
    padding: theme.spacing(2),
    position: 'absolute',
    top: theme.spacing(5)
}));

const DialogTitleStyled = styled(DialogTitle)({
    paddingRight: '0px'
});

export default function Popup(props) {
    const { title, children, openPopup, setOpenPopup } = props;

    return (
        <DialogWrapper open={openPopup} maxWidth="md">
            <DialogTitleStyled>
                <div style={{ display: 'flex' }}>
                    <Typography variant="h6" component="div" style={{ flexGrow: 1 }}>
                        {title}
                    </Typography>
                    <IconButton onClick={() => { setOpenPopup(false) }}>
                        <CloseIcon />
                    </IconButton>
                </div>
            </DialogTitleStyled>
            <DialogContent dividers>
                {children}
            </DialogContent>
        </DialogWrapper>
    );
}