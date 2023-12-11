import React from 'react';
import { Table as MuiTable, styled } from '@mui/material';

const StyledTable = styled(MuiTable)({
    '& tbody td': {
        fontWeight: '300',
    },
    '& tbody tr:hover': {
        backgroundColor: '#fffbf2',
        cursor: 'pointer',
    },
    '& .MuiTableCell-root': {
        border: 'none'
    }
});

export default function Table(props) {
    return (
        <StyledTable>
            {props.children}
        </StyledTable>
    );
}
