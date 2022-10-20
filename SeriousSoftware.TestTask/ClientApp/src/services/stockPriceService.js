import moment from 'moment';

const formatDate = (date) => {
    return moment(date).format('YYYY-MM-DD');
}

export const calculatePerformance = async (value, startDate, endDate) => {
    const response = await fetch(`https://localhost:7085/StockPrice/CalculatePerformance/${value}?start=${formatDate(startDate)}&end=${formatDate(endDate)}`);
    return await response.json();
}

export const storeStockPrices = async (value, startDate, endDate) => {
    const response = await fetch(`https://localhost:7085/StockPrice/StoreStockPrices/${value}?start=${formatDate(startDate)}&end=${formatDate(endDate)}`, {method: 'POST'});
    return await response.json();
}

export const loadStockPrices = async (value, startDate, endDate) => {
    const response = await fetch(`https://localhost:7085/StockPrice/GetPolygonStockData/${value}?start=${formatDate(startDate)}&end=${formatDate(endDate)}`);
    const data = await response.json();
    return data.polygonResults.map(r => ({
        date: new Date(r.timeStamp),
        open: r.open,
        high: r.high,
        low: r.low,
        close: r.close,
        volume: r.volume
    }));
}