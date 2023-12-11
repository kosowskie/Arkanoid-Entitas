import React from 'react';
import { List, ListItemText, Paper, ListItem, ListItemSecondaryAction, IconButton, ButtonGroup, Button, styled } from '@mui/material';
import DeleteTwoToneIcon from '@mui/icons-material/DeleteTwoTone';
import { roundTo2DecimalPoint } from "../../utils";

const StyledPaper = styled(Paper)(({ theme }) => ({
    margin: '15px 0px',
    '&:hover': {
        cursor: 'pointer',
        '& $StyledDeleteButton': {
            display: 'block'
        }
    }
}));

const StyledButtonGroup = styled(ButtonGroup)(({ theme }) => ({
    backgroundColor: '#E3E3E3',
    borderRadius: 8,
    '& .MuiButtonBase-root ': {
        border: 'none',
        minWidth: '25px',
        padding: '1px'
    },
    '& button:nth-child(2)': {
        fontSize: '1.2em',
        color: '#000'
    }
}));

const StyledDeleteButton = styled(IconButton)({
    display: 'none',
    '& .MuiButtonBase-root': {
        color: '#E81719'
    },
    '&:hover': {
        backgroundColor: 'transparent'
    }
});

const TotalPerItem = styled('span')({
    fontWeight: 'bolder',
    fontSize: '1.2em',
    margin: '0px 10px'
});

export default function OrderedFoodItems(props) {

    const { values, setValues } = props;

    let orderedFoodItems = values.orderDetails;

    const removeFoodItem = (index, id) => {
        let x = { ...values };
        x.orderDetails = x.orderDetails.filter((_, i) => i !== index);
        if (id !== 0)
            x.deletedOrderItemIds += id + ',';
        setValues({ ...x });
    }

    const updateQuantity = (idx, value) => {
        let x = { ...values };
        let foodItem = x.orderDetails[idx];
        if (foodItem.quantity + value > 0) {
            foodItem.quantity += value;
            setValues({ ...x });
        }
    }

    return (
        <List>
            {orderedFoodItems.length === 0 ?
                <ListItem>
                    <ListItemText
                        primary="Please select food items"
                        primaryTypographyProps={{
                            style: {
                                textAlign: 'center',
                                fontStyle: 'italic'
                            }
                        }}
                    />
                </ListItem>
                : orderedFoodItems.map((item, idx) => (
                    <StyledPaper key={idx}>
                        <ListItem>
                            <ListItemText
                                primary={item.foodItemName}
                                primaryTypographyProps={{
                                    component: 'h1',
                                    style: {
                                        fontWeight: '500',
                                        fontSize: '1.2em'
                                    }
                                }}
                                secondary={
                                    <>
                                        <StyledButtonGroup size="small">
                                            <Button onClick={e => updateQuantity(idx, -1)}>-</Button>
                                            <Button disabled>{item.quantity}</Button>
                                            <Button onClick={e => updateQuantity(idx, 1)}>+</Button>
                                        </StyledButtonGroup>
                                        <TotalPerItem>
                                            {'PLN ' + roundTo2DecimalPoint(item.quantity * item.foodItemPrice)}
                                        </TotalPerItem>
                                    </>
                                }
                            />
                            <ListItemSecondaryAction>
                                <StyledDeleteButton onClick={e => removeFoodItem(idx, item.foodItemId)}>
                                    <DeleteTwoToneIcon />
                                </StyledDeleteButton>
                            </ListItemSecondaryAction>
                        </ListItem>
                    </StyledPaper>
                ))
            }
        </List>
    );
}
