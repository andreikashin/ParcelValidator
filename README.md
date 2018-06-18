# Parcel Validator

#### ParcelValidator inspects the passability of pipeline corners.

##### Input
Input expects *integer* CSV. 
Two first values are parcel's dimensions.
Others are representing pipeline right-angled elbow dimensions.

##### Algorithm
In case of *equal* dimensions of the elbow algorithm compares 
distance between elbow corners and parcel half-length.
Otherwise, calculates maximum passable length of the parcel of
given width in appliance to the elbow dimensions. 
If width is too large in first case, or actual length exceeds calculated value in second situation, then elbow is considered impassable.
