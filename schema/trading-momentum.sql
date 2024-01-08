DROP TABLE IF EXISTS momentum;
CREATE TABLE IF NOT EXISTS momentum (id INTEGER PRIMARY KEY, indicator TEXT, ticker TEXT, timeframe TEXT, delta REAL, score REAL, price REAL, year TEXT, month TEXT, day TEXT, hour TEXT, minute TEXT);
INSERT INTO momentum (id, indicator, ticker, timeframe, delta, score, price, year, month, day, hour, minute) VALUES (1, 'RSI', 'BTCUSD', 'M', 0, 50, 1000000, '2023','12','28','01','01'), (2, 'RSI', 'BTCUSD', 'W', 0, 50, 1000000, '2023','12','28','01','01'), (3, 'RSI', 'BTCUSD', 'D', 0, 50, 1000000, '2023','12','28','01','01'), (4, 'RSI', 'BTCUSD', '240', 0, 50, 1000000, '2023','12','28','01','01'), (5, 'RSI', 'BTCUSD', '45', 0, 50, 1000000, '2023','12','28','01','01'), (6, 'RSI', 'BTCUSD', '5', 0, 50, 1000000, '2023','12','28','01','01');

CREATE INDEX IF NOT EXISTS idx_momentum_ticker ON momentum(ticker)

-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_ticker ON momentum(ticker)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_timeframe ON momentum(timeframe)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_indicator ON momentum(indicator)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_year ON momentum(year)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_month ON momentum(month)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_day ON momentum(day)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_hour ON momentum(hour)"
-- wrangler d1 execute trading --command="CREATE INDEX IF NOT EXISTS idx_momentum_minute ON momentum(minute)" 

