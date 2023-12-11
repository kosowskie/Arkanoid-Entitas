import React from 'react';
import { Button as MuiButton, styled } from "@mui/material";

const StyledButton = styled(MuiButton)(({ theme }) => ({
    margin: theme.spacing(1),
    '& .MuiButton-label': {
        textTransform: 'none'
    }
}));

export default function Button(props) {
    const { children, color, variant, onClick, className, ...other } = props;

    return (
        <StyledButton
            className={className}
            variant={variant || "contained"}
            color={color || "inherit"}
            onClick={onClick}
            {...other}>
            {children}
        </StyledButton>
    );
}
