//@version=5
indicator("AUscilator", overlay=true)

rsi = ta.rsi(close, 7)
rsiTrendUpDown = ta.ema(rsi, 35)
rsiTrend = ta.sma(rsi, 60)
var float rsiTrendSmooth = na
rsiTrendSmooth := na(rsiTrendSmooth[1]) ? rsiTrend : (nz(rsiTrendSmooth[1]) * (60 - 1) + rsi) / 60

// rsiVwma = ta.vwma(rsi, 28)
// rsiEma = ta.ema(rsi, 1)

price = close
priceTrend = ta.sma(close, 60)
var float priceTrendSmooth = na
priceTrendSmooth := (na(priceTrendSmooth[1]) ? priceTrend : (nz(priceTrendSmooth[1]) * (60 - 1) + price) / 60)

// priceWma = ta.wma(close, 30)

priceOne = (price*0.01)
// priceCrossing = math.abs(priceVwma - priceWma) < priceOne

rsiChange = rsi - rsi[1]
rsiChangeAbs = math.abs(rsiChange)

rsiTrendUpDownDirection = rsiTrendUpDown - rsiTrendUpDown[1]

// rsiOkToSell = (rsi - rsiChangeAbs) > (rsiTrendUpDown + 15)
rsiOkToSell = (rsi > (rsiTrendSmooth - 5))

// rsiOkToBuy = (rsi < (rsiTrendUpDown - 12)) and (rsi < 43) and (rsi[1] > rsi)
//  and (rsi[1] < (rsiTrendUpDown[1] - 12)) and (rsi[1] < 43) and (rsiTrendUpDownDirection > 0)
rsiOkToBuy = (rsi < (rsiTrendUpDown - 10))

// color_buy1 = buy ? color.green : na
// color_sell1 = sell ? color.red : na
color_okToBuy = (rsiOkToBuy) ? color.rgb(67, 199, 67) : na
color_okToSell = (rsiOkToSell) ? color.rgb(222, 67, 67) : na

// plot(close - (priceOne*0), "okToBuy", color=color_okToBuy, linewidth=2)
// plot(close - (priceOne*0.5), "okToSell", color=color_okToSell, linewidth=2)
// plot(priceTrendSmooth, "trend", color=color.gray, linewidth=1)
// plot(priceTrendSmooth - (priceOne*1.5), "buy2", color=color_buy2, linewidth=4)
// plot(priceTrendSmooth - (priceOne*2), "sell2", color=color_sell2, linewidth=2)


// var float lowestVisiblePrice = na
//     lowestVisiblePrice := low
// if barstate.islastconfirmedhistory
// lowestPrice = request.security(syminfo.tickerid, "D", low[1], lookahead = barmerge.lookahead_on)
// if not na(lowestVisiblePrice)
//     if lowestVisiblePrice > lowestPrice
//         lowestVisiblePrice := lowestPrice
plot(1600+ ((price - priceTrendSmooth) / 2), "histogram", color.gray, style = plot.style_line)
plot(1600, "zero", color.gray, style = plot.style_line)

// var float lowestVisiblePrice = na

// if barstate.islastconfirmedhistory
//     lowestVisiblePrice := low

// lowestPrice = request.security(syminfo.tickerid, "D", low[1], lookahead = barmerge.lookahead_on)

// if not na(lowestVisiblePrice)
//     if lowestVisiblePrice > lowestPrice
//         lowestVisiblePrice := lowestPrice

// plot(lowestVisiblePrice, "Lowest Visible Price", color=color.red)