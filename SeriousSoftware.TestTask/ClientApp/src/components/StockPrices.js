import React, { useState } from 'react';
import { TypeChooser } from "react-stockcharts/lib/helper";
import Chart from './Chart';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { loadStockPrices, calculatePerformance, storeStockPrices } from '../services/stockPriceService.js';

export const StockPrices = () => {

    const [prices, setPrices] = useState([]);
    const [value, setValue] = useState("MSFT");
    const [isLoading, setIsLoading] = useState(true);
    const [startDate, setStartDate] = useState(new Date().setDate(new Date().getDate() - 7));
    const [endDate, setEndDate] = useState(new Date());

    const handleChange = (event) => {
        setValue(event.target.value);
    }

    const loadPrices = async () => {
        const prices = await loadStockPrices(value, startDate, endDate);
        setPrices(prices);
        setIsLoading(false);
    }

    const calculate = async () => {
        await calculatePerformance(value, startDate, endDate);
        setIsLoading(false);
    }

    const store = async () => {
        await storeStockPrices(value, startDate, endDate);
    }

    return (
        <div>
            <h1 id="tabelLabel" >Stock Prices</h1>
            <p>Sorry, had no time for styling</p>
            <ul>
                <li>You can select date range and stock which will be shown on the chart.</li>
                <li>Performance Calculation api is present(with one unit test), but the data is never shown.</li>
                <li>To compare performance of two stock I would make two api calls and show on the same chart,
                    but it would require more time because there is no such simple example for the react charts library that I used.</li>
                <li>Storing into database is implemented, but the data is never retrieved</li>

                <li>This test project is a mix of "something here, something there".
                    In order to implement it with better UI, with proper displaying stock data and it's performance,
                    saving data and so on it would require more time than 4-8 hours. Especially when you need to write everything from scratch.</li>
            </ul>
            
            
            <p>Select date range and stock</p>

            <h6>From:</h6>
            <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} />

            <h6>To:</h6>
            <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} />

            <h6>Stock</h6>
            <input type="text" value={value} onChange={(value) => handleChange(value)} />
            <input type="button" value="Load prices" onClick={loadPrices} />
            <input type="button" value="Calculate performance" onClick={calculate} />
            <input type="button" value="Store" onClick={store} />

            {isLoading ? <p><em>Loading...</em></p>
                : <TypeChooser>
                    {type => <Chart type={type} data={prices} />}
                </TypeChooser>
            }

        </div>
    );
}