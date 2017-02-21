$(document).ready(function () {
    // create DatePicker from input HTML element
    $("#datePicker").kendoDatePicker({
        value: new Date(),
        min: new Date(),
        format: "dd/MM/yyyy"
    }); 
});