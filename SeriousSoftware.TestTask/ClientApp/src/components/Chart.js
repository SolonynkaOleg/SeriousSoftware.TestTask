
import React from "react";
import PropTypes from "prop-types";

import { scaleTime } from "d3-scale";
import { utcDay } from "d3-time";

import { ChartCanvas, Chart } from "react-stockcharts";
import { CandlestickSeries } from "react-stockcharts/lib/series";
import { XAxis, YAxis } from "react-stockcharts/lib/axes";
import { fitWidth } from "react-stockcharts/lib/helper";
import { last, first, timeIntervalBarWidth } from "react-stockcharts/lib/utils";
import { discontinuousTimeScaleProvider } from "react-stockcharts/lib/scale";

class CandleStickChart extends React.Component {
	render() {
		const { type, width, data: initialData, ratio } = this.props;
		const xScaleProvider = discontinuousTimeScaleProvider
			.inputDateAccessor(d => d.date);
		const {
			data,
		} = xScaleProvider(initialData);
		const xExtents = [first(data), last(data)];
		return (
			<ChartCanvas height={400}
				ratio={ratio}
				width={width}
				margin={{ left: 50, right: 50, top: 10, bottom: 30 }}
				type={type}
				seriesName="MSFT"
				data={data}
				xAccessor={d => d.date}
				xScale={scaleTime()}
			>

				<Chart id={1} yExtents={d => [d.high, d.low]}>
					<XAxis axisAt="bottom" orient="bottom" ticks={6} />
					<YAxis axisAt="left" orient="left" ticks={5} />
					<CandlestickSeries width={timeIntervalBarWidth(utcDay)} />
				</Chart>
			</ChartCanvas>
		);
	}
}

CandleStickChart.propTypes = {
	data: PropTypes.array.isRequired,
	width: PropTypes.number.isRequired,
	ratio: PropTypes.number.isRequired,
	type: PropTypes.oneOf(["svg", "hybrid"]).isRequired,
};

CandleStickChart.defaultProps = {
	type: "svg",
};
CandleStickChart = fitWidth(CandleStickChart);

export default CandleStickChart;
