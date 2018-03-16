- a **plot** is composed of **series** and **axis sets**
- a **series** is defined by a **title**, **data**, and **scaling type**
	- the **title** is a string value
	- the **data** is either an algebraic function, or coordinate pairs
		- algebraic functions are univariate 
		- coordinate data, and function input and output values, use 64-bit 
		  floating-point binary representation (i.e. "double")
		- **x** and **y** describe the coordinate variables
	- for any series, a **domain** and **range** can be found as **intervals**
		- an **interval** is either the empty interval, or an ordered pair of values
			- *TODO: should intervals carry the concept of inclusive / exclusive endpoints?*
			- the **union** of two intervals is
			- the **width** of an interval is the difference between its bounds
				- the empty interval, if both intervals are empty,
				- the non-empty argument, if one argument is empty and the other is not,
				- a single interval of the least of the two lower bounds, and the greater of the two upper bounds
		- the **union** of a sequence of intervals is the aggregation of unions over the sequence,
		  using the empty interval as the seed value
		- an interval is **finite** if both bounds are finite
	- the **domain** of a algebraic function series is the union of
		- the union of each interval of the function domain, if every interval on its domain is finite
		- the **x** location for each known or discoverable **feature** of the function, where the set
		  features for the function is known to be finite, or where a finite set can be discovered
			- known features (or **x** locations thereof) may be tabulated for well-known functions
			- discoverable features may be found using numerical analysis of the function
			  and/or its derivatives
			- **features** include
				- singularities in the function output
				- turning points
				- zero crossings
		- the **well-known domain** of a function, if it exists
		- optionally, the interval [0,0], if it lies less than one interval width away from the domain
		  calculated from the preceding steps
			- the inclusion or exclusion of [0,0] may be overridden by a user option
		- the interval [-10, 10], if the interval calculated from the preceding steps
		  is empty or of zero width
	- the domain of coordinate data is the union of
		- the interval which bounds every non-excluded data point
			- data points may be explicitly removed from domain calculation
				- if a data point is removed from domain calculation, it must also be removed from range calculation
		- optionally, the interval [0,0] as for algebraic functions above
		- the interval [-10, 10] if the interval calculated from the preceding steps
		  is empty or of zero width
			- *TODO: what if e.g. single point at [10000, 10000] with no [0,0] ?*
	- the range of an algebraic function is the union of intervals calculated as follows:
		- divide domain into segments based on feature locations
		- if the function value exists at a segment boundary, the segment range interval includes that
		  value
		- if the function value at the segment has a finite limit from any direction, the segment range interval bound
		  includes all limits
		- otherwise, if segment starts or ends in asymptote, back off 10% of segment width and set range bound at function value
		- [0,0] optionally as for domains
		- [-10, 10] fallback as for domains
	- the range of coordinate data is the union of
		- the interval which bounds every non-excluded data point
			- data points may be excluded as for domain calculation
		- [0,0] optionally as for domain
		- [-10, 10] fallback as for domain
- an axis set is composed of two axes: an **abcissa** and an **ordinate**
	- an **axis** has a **scaling type**
	- the **scaling type** of a series is *linear*, *semilog-x*, *semilog-y*, or *log-log*
		- where a coordinate is to be scaled logarithmically, where appropriate the logarithm
		  of the data or function should be used in place of the actual value
			- *TODO: wooly*