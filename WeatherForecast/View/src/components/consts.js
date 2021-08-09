const Days = [
    "Sunday",
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
];
const Months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
];

//convert timestamp to the day of the week
export function getDay(timestamp) {
    const DayIndex = new Date(timestamp).getDay();
    return Days[DayIndex];
}
//convert timestamp to the month
export function getMonth(timestamp) {
    const MonthIndex = new Date(timestamp).getMonth();
    return Months[MonthIndex];
}