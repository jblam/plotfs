Data is parsed only from strings.

- delimiting substrings are inferred such that the input can be parsed to rows and columns
- the columns delimiter is whitespace surrounded by any contiguous characters which do not afford parsing as a floating point number
  - *TODO*: possibly *([^0-9]+\s+[^0-9]+)*
- the rows delimiter is any number of consecutive line delimiting characters, i.e. *[\r\n+]*
- the orientation of the data is either *rows* or *columns*, depending on which has the greater rank
  - enumerating elements in the oriented direction gives the sequence of values which are used as the inputs for coordinates
    - *TODO* wat. I'm trying to say, I want to define the term *vector* along the long axis of the data matrix.
- coordinate pairs are inferred based on the coordinate inference mode
  - in *single mode* the single vector provides ordinate values, and the index provides the abcissa value
  - in *abcissa-first mode* the first vector provides the common abcissa; the subsequent vectors define ordinate values for individual series
  - in *pair mode* the vectors are paired to form series such that the first provides the abcissa, and the second provides the ordinate
  - if the minor rank of the data matrix is 1, only the *single mode* may be used
  - if the 