CREATE TABLE urlidentifiers (
  id numeric PRIMARY KEY,
  url_identifier VARCHAR(10) UNIQUE
);

CREATE TABLE locations (
  url_identifier VARCHAR(10) PRIMARY KEY,
  uri TEXT,
  CONSTRAINT fK_urlidentifiers_locations
	FOREIGN KEY(url_identifier)
	REFERENCES urlidentifiers(url_identifier)
);