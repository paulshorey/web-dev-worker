DROP TABLE IF EXISTS events;

CREATE TABLE IF NOT EXISTS events 
(id INTEGER PRIMARY KEY, ticker TEXT, price REAL, year TEXT, month TEXT, day TEXT, hour TEXT, minute TEXT, timestamp REAL);

INSERT INTO events (id, ticker, price, year, month, day, hour, minute, timestamp) 
VALUES (1, 'BTCUSD', 1000000, '2023','12','28','01','01', 1704081044113);

CREATE INDEX IF NOT EXISTS idx_events_ticker ON events(ticker)
CREATE INDEX IF NOT EXISTS idx_events_timeframe ON events(timeframe)
CREATE INDEX IF NOT EXISTS idx_events_indicator ON events(indicator)
CREATE INDEX IF NOT EXISTS idx_events_year ON events(year)
CREATE INDEX IF NOT EXISTS idx_events_month ON events(month)
CREATE INDEX IF NOT EXISTS idx_events_day ON events(day)
CREATE INDEX IF NOT EXISTS idx_events_hour ON events(hour)
CREATE INDEX IF NOT EXISTS idx_events_minute ON events(minute)"

-- wrangler d1 execute trading --command=""

