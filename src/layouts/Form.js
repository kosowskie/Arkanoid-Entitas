import React from 'react';
import { styled } from '@mui/material/styles';

const StyledForm = styled('form')(({ theme }) => ({
    '& .MuiFormControl-root': {
        width: '90%',
        margin: theme.spacing(1)
    }
}));

export default function Form(props) {
    const { children, ...other } = props;

    return (
        <StyledForm noValidate {...other}>
            {children}
        </StyledForm>
    );
}