//@version=5
indicator("Learning", overlay=true)

rsi = ta.rsi(close, 7)
rsiVwma = ta.vwma(rsi, 28)
rsiEma = ta.ema(rsi, 4)

price = close
priceTrend = ta.sma(close, 90)
priceVwma = ta.vwma(close, 7)
priceWma = ta.wma(close, 7)

priceOne = (price*0.01)
priceCrossing = math.abs(priceVwma - priceWma) < priceOne

rsiBullish = (rsiEma < rsiEma[1]) 
okToBuy = rsiBullish

rsiBearish = (rsiEma > rsiEma[1])
okToSell = (( rsiEma +1 )  < rsiEma[1]) and (rsiEma[1] > rsiEma[2])

sell = (rsiEma > rsiVwma) and ((rsiEma / rsiVwma) > 1.1)
buy = (rsiEma < rsiVwma) and ((rsiEma / rsiVwma) < 0.9)

color_action = buy ? color.green : sell ? color.red : na
color_buy = (okToBuy) ? color.rgb(67, 99, 67) : na
color_sell = (okToSell) ? color.rgb(155, 67, 67) : na

plot(priceTrend, "rsi", color=color_action, linewidth=2)
plot(priceTrend - (priceOne*2), "buy", color=color_buy, linewidth=4)
plot(priceTrend - (priceOne*4), "sell", color=color_sell, linewidth=6)
