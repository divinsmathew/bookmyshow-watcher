# BMS Watcher

This project is a mini web-crawler that alerts user when tickets are available on a new theatre in BookMyShow. 

- Goto the ticket booking page of any movie. URL will contain path `/buytickets`.
- Copy the movie ID from the URL. This is the part that comes after `buytickets/`.

  Eg: For the URL: `https://in.bookmyshow.com/buytickets/avengers-infinity-war/ET00073462/20170428`, <br>
  expected ID would be `avengers-infinity-war/ET00073462/20170428`.
- Paste it on the program and start watching. You'll be alerted when the thetr count is changed.
