
//@version=5
strategy("RSI Momentum", overlay=true, pyramiding=0 )
rsiALength = input(7)
rsiBLength = input(2)
rsiCLength = input(30)
rsiTLength = input(42)
priceALength = 1
priceBLength = input(2)
priceTLength = input(100)

// Suffixes:
// A = immediate, no offset
// B = small offset, like 2
// T = large offset, like 42
// X = compare same line, in different times
// D = difference 2 lines, at the same time
// 1 = previous close

rsiA = ta.rsi(close, rsiALength)
rsiB = ta.sma(rsiA, rsiBLength)
rsiC = ta.sma(rsiA, rsiCLength)
rsiT = ta.sma(rsiA, rsiTLength)
priceA = close
priceB = ta.sma(close, priceBLength)
priceT = ta.sma(close, priceTLength)

rsiAX = rsiA - rsiA[1]
rsiBX = rsiB - rsiB[1]
rsiCX = rsiC - rsiC[1]
rsiABD = rsiA - rsiB
rsiABD1 = rsiA[1] - rsiB[1]
rsiATD = rsiA - rsiT
rsiTX = rsiT - rsiT[1]
priceTX = priceT - priceT[1]
rsiBTD = rsiB - rsiT

rsiAWeek = request.security(syminfo.tickerid, "W", ta.rsi(close, rsiALength))
// rsiBWeekX = request.security(syminfo.tickerid, "W", ta.sma(rsiAWeek, rsiBLength))
rsiWeekX = rsiAWeek - rsiAWeek[1] 
rsiBullish = input(80) - rsiA
rsiBearish = input(50) - rsiA

// up
longX = true
  and (
  (rsiABD > 1.9 and rsiABD < 3.9) // rsiA>rsiB, significantly but not too much
  or ((rsiABD > 1) and (rsiBTD < -10))
  )
  and (
  (rsiABD1 < -1.9 and rsiABD1 > -3.9) // rsiA1<rsiB1, significantly but not too much
  or ((rsiABD1 < -1) and (rsiBTD < -10)) // or crossed over while significantly oversold
  )
longA = true
  and (rsiBullish > 0)
  and (rsiBTD < 1) // long term oversold or flat
  and (rsiTX > -1) // long term (rsi) trending up or flat
  // crossed
  and longX
  // long term
  and (rsiWeekX > 0)
  
// down
shortX = true 
  and (
  (rsiABD < -1.9 and rsiABD > -3.9)
  or ((rsiABD < -1) and (rsiBTD > 10))
  )
  and (
  (rsiABD1 > 1.9 and rsiABD1 < 3.9)
  or ((rsiABD1 > 1) and (rsiBTD > 10)) 
  )
  // crossed
shortA = true
  and (rsiBearish > 0) 
  and (rsiBTD > 1)
  and (rsiTX < 1) 
  // crossed
  and shortX
  // long term
  and (rsiWeekX < 0)

// Execute
if (shortA)
    strategy.entry("RsiSE", strategy.short, comment="short")
if (longA)
    strategy.entry("RsiLE", strategy.long, comment="long")