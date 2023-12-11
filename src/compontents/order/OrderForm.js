import React, { useState, useEffect } from 'react'
import Form from "../../layouts/Form";
import { Grid, InputAdornment, ButtonGroup, Button as MuiButton } from '@mui/material';
import { Input, Select, Button } from "../../controls";
import ReplayIcon from '@mui/icons-material/Replay';
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu';
import ReorderIcon from '@mui/icons-material/Reorder';
import { createAPIEndpoint, ENDPIONTS } from "../../api";
import { roundTo2DecimalPoint } from "../../utils";
import Popup from '../../layouts/Popup';
import OrderList from './OrderList';
import Notification from "../../layouts/Notification";
import { styled } from '@mui/system';

const paymentMethod = [
    { id: 'none', title: 'Select' },
    { id: 'Cash', title: 'Cash' },
    { id: 'Card', title: 'Card' },
]

const AdornmentText = styled('div')(({ theme }) => ({
    '& .MuiTypography-root': {
        color: '#f3b33d',
        fontWeight: 'bolder',
        fontSize: '1.5em',
    },
}));
  
const SubmitButtonGroup = styled(ButtonGroup)(({ theme }) => ({
    backgroundColor: '#f3b33d',
    color: '#000',
    margin: theme.spacing(1),
    '& .MuiButton-label': {
        textTransform: 'none',
    },
    '&:hover': {
        backgroundColor: '#f3b33d',
    },
}));

export default function OrderForm(props) {
    const { values, setValues, errors, setErrors,
        handleInputChange, resetFormControls } = props;

    const [customerList, setCustomerList] = useState([]);
    const [orderListVisibility, setOrderListVisibility] = useState(false);
    const [customerOrderId, setCustomerOrderId] = useState(0);
    const [notify, setNotify] = useState({ isOpen: false });

    
    useEffect(() => {
        createAPIEndpoint(ENDPIONTS.CUSTOMER).fetchAll()
            .then(res => {
                const updatedCustomerList = res.data.map(item => ({
                    id: item.customerId,
                    title: item.customerName
                }));
                setCustomerList(prevList => [...prevList, ...updatedCustomerList]);
            })
            .catch(err => console.log(err))
    }, []);


    useEffect(() => {
        let totalPrice = values.orderDetails.reduce((tempTotal, item) => {
            return tempTotal + (item.quantity * item.foodItemPrice);
        }, 0);
        setValues({
            ...values,
            totalPrice: roundTo2DecimalPoint(totalPrice)
        })

    }, [JSON.stringify(values.orderDetails)]);

    useEffect(() => {
        if (customerOrderId == 0) resetFormControls()
        else {
            createAPIEndpoint(ENDPIONTS.ORDER).fetchById(customerOrderId)
                .then(res => {
                    setValues(res.data);
                    setErrors({});
                })
                .catch(err => console.log(err))
        }
    }, [customerOrderId]);

    const validateForm = () => {
        let temp = {};
        temp.customerId = values.customerId != 0 ? "" : "This field is required.";
        temp.paymentMethod = values.paymentMethod != "none" ? "" : "This field is required.";
        temp.orderDetails = values.orderDetails.length != 0 ? "" : "This field is required.";
        setErrors({ ...temp });
        return Object.values(temp).every(x => x === "");
    }

    const resetForm = () => {
        resetFormControls();
        setCustomerOrderId(0);
    }

    const submitOrder = e => {
        e.preventDefault();
        if (validateForm()) {
            if (values.customerOrderId == 0) {
                createAPIEndpoint(ENDPIONTS.ORDER).create(values)
                    .then(res => {
                        resetFormControls();
                        setNotify({isOpen:true, message:'New order is created.'});
                    })
                    .catch(err => console.log(err));
            }
            else {
                createAPIEndpoint(ENDPIONTS.ORDER).update(values.customerOrderId, values)
                    .then(res => {
                        setCustomerOrderId(0);
                        setNotify({isOpen:true, message:'The order is updated.'});
                    })
                    .catch(err => console.log(err));
            }
        }

    }

    const openListOfOrders = () => {
        setOrderListVisibility(true);
    }

    return (
        <>
            <Form onSubmit={submitOrder}>
                <Grid container>
                    <Grid item xs={6}>
                        <Input
                            disabled
                            label="Order Number"
                            name="orderNumber"
                            value={values.orderNumber}
                            InputProps={{
                                startAdornment: (
                                  <InputAdornment position="start">
                                    <AdornmentText>#</AdornmentText>
                                  </InputAdornment>
                                ),
                            }}
                        />
                        <Select
                            label="Customer"
                            name="customerId"
                            value={values.customerId}
                            onChange={handleInputChange}
                            options={customerList}
                            error={errors.customerId}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Select
                            label="Payment Method"
                            name="paymentMethod"
                            value={values.paymentMethod}
                            onChange={handleInputChange}
                            options={paymentMethod}
                            error={errors.paymentMethod}
                        />
                        <Input
                            disabled
                            label="Grand Total"
                            name="totalPrice"
                            value={values.totalPrice}
                            InputProps={{
                                startAdornment: (
                                    <InputAdornment position="start">
                                        <AdornmentText>PLN </AdornmentText> {}
                                    </InputAdornment>
                                ),
                            }}
                        />
                        <SubmitButtonGroup>
                            <Button
                              size="large"
                              endIcon={<RestaurantMenuIcon />}
                              type="submit"
                              onClick={submitOrder}
                            >
                              Submit
                            </Button>
                            <Button
                              size="small"
                              onClick={resetForm}
                              startIcon={<ReplayIcon />}
                            />
                        </SubmitButtonGroup>
                        <Button
                            size="large"
                            onClick={openListOfOrders}
                            startIcon={<ReorderIcon />}
                        >Orders</Button>
                    </Grid>
                </Grid>
            </Form>
            <Popup
                title="List of Orders"
                openPopup={orderListVisibility}
                setOpenPopup={setOrderListVisibility}>
                <OrderList
                    {...{ setCustomerOrderId, setOrderListVisibility,resetFormControls,setNotify }} />
            </Popup>
            <Notification
                {...{ notify, setNotify }} />
        </>
    )
}