var parseFloat2 = function (arg) {
    if (typeof (arg) === "undefined") {
        return null;
    };
	
	if(!arg){
		return null;
	};

    var input = arg;

    if (window.currencySymbol) {
        input = input.toString().replace(window.currencySymbol, "");
    };

    var val = parseFloat(parseFormattedNumber(input.toString()) || 0);

    if (isNaN(val)) {
        val = 0;
    }

    return val;
};

var parseInt2 = function (arg) {
    if (typeof (arg) === "undefined") {
        return null;
    };
	
	if(!arg){
		return null;
	};

    var val = parseInt(parseFormattedNumber(arg.toString()) || 0);

    if (isNaN(val)) {
        val = 0;
    }

    return val;
};

function parseDate(str) {
    return new Date(Date.parse(str));
};

function parseSerializedDate(str) {
    str = str.replace(/[^0-9 +]/g, '');
    return new Date(parseInt(str));
};

function round(number, decimalPlaces) {    
    return +(Math.round(number + "e+" + decimalPlaces)  + "e-" + decimalPlaces);
};