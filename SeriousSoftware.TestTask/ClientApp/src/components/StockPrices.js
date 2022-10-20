import React, { Component } from 'react';
import { TypeChooser } from "react-stockcharts/lib/helper";
import Chart from './Chart';

export class StockPrices extends Component {
    static displayName = StockPrices.name;

    constructor(props) {
        super(props);
        this.state = { prices: [], value: "", loading: true };
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    loadPrices() {
        this.populateWeatherData(this.state.value);
    }

    calculate() {
        this.calculatePerformance(this.state.value);
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <TypeChooser>
                {type => <Chart type={type} data={this.state.prices} />}
              </TypeChooser>;

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
               
                <input type="text" value={this.state.value} onChange={this.handleChange.bind(this)} />
                <input type="button" value="Load prices" onClick={this.loadPrices.bind(this)} />
                <input type="button" value="Calculate performance" onClick={this.calculate.bind(this)} />
                {contents}
            </div>
        );
    }

    async populateWeatherData(value) {
        const response = await fetch(`weatherforecast/GetPolygonStockData/${value}`);
        const data = await response.json();
        const prices = data.polygonResults.map(r => ({
            date: new Date(r.timeStamp),
            open: r.open,
            high: r.high,
            low: r.low,
            close: r.close,
            volume: r.volume
        }));

        this.setState({ prices: prices, loading: false });
    }

    async calculatePerformance(value) {

    }

    parseData(parse) {
        return function (d) {
            d.date = parse(d.date);
            d.open = +d.open;
            d.high = +d.high;
            d.low = +d.low;
            d.close = +d.close;
            d.volume = +d.volume;

            return d;
        };
    }
}