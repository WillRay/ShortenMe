CREATE TABLE UrlIdentifiers (
  id numeric PRIMARY KEY,
  url_identifier VARCHAR(10) UNIQUE
);

CREATE TABLE Locations (
  url_identifier VARCHAR(10) PRIMARY KEY,
  uri TEXT,
  CONSTRAINT fK_token_location
	FOREIGN KEY(url_identifier)
	REFERENCES Tokens(url_identifier)
);