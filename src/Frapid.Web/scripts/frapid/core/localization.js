function setRegionalFormat()
{
    if (typeof decimalSeparator === "undefined" || typeof thousandSeparator === "undefined") {
        return;
    };

	var candidates = $("input.decimal:not(.hasCleave):not(:disabled):not([readonly]), input.decimal4:not(.hasCleave):not(:disabled):not([readonly]), input.integer:not(.hasCleave):not(:disabled):not([readonly]), input.currency:not(.hasCleave):not(:disabled):not([readonly])");	
	$.each(candidates, function(){
	    var el = $(this).addClass("hasCleave");
	    var prefix = "";
	    var decimalPlaces = window.currencyDecimalPlaces || 2;
		
		if(el.is(".currency")){
			prefix = window.currencySymbol;
		};
		
		if(el.is(".integer")){
			decimalPlaces = 0;
		};
		
		if(el.is(".decimal4")){
			decimalPlaces = 4;
		};
		
		new Cleave(this, {
			numeral: true,
			numeralThousandsGroupStyle: 'thousand',
			numeralDecimalScale: decimalPlaces,
			numeralDecimalMark: decimalSeparator,
			delimiter: thousandSeparator,
			prefix: prefix
		});
	});	

	var disabledOnes = $("input.decimal[disabled],input.decimal[readonly],input.decimal4[disabled], input.decimal4[readonly],input.currency[disabled], input.currency[readonly],input.integer[disabled], input.integer[readonly]");

	disabledOnes.on("change", function(){
		var el = $(this);
		var value = el.val();
		
		if(!value){
			return;
		};
		
		var number = window.parseFloat2(value);
		var isInteger = el.is(".integer");
		
		el.val(window.getFormattedNumber(number, isInteger));
	});
};


(function ($) {
  var originalVal = $.fn.val;
  $.fn.val = function(value) {
    if (arguments.length >= 1) {
      // setter invoked, do processing	  
      var value = originalVal.call(this, value); 
	  return value;
    };
	
	var el =$(this[0]);
	
	if(el.is("input.decimal, input.decimal4, input.integer")){
		return getRawCleaveValue(this[0]);
	}else{
		return originalVal.call(this);
	};
  };
})(jQuery);



function getRawCleaveValue(el){
	var cleave;
	
	if($(el).is(".decimal")){
		cleave = new Cleave(el, {
			numeral: true,
			numeralThousandsGroupStyle: 'thousand',
			numeralDecimalScale: window.currencyDecimalPlaces || 2,
			numeralDecimalMark: decimalSeparator,
			delimiter: thousandSeparator
		});		
	};
	
	if($(el).is(".decimal4")){
		cleave = new Cleave(el, {
			numeral: true,
			numeralThousandsGroupStyle: 'thousand',
			numeralDecimalScale: 4,
			numeralDecimalMark: decimalSeparator,
			delimiter: thousandSeparator
		});		
	};
	
	if($(el).is(".integer")){
		cleave = new Cleave(el, {
			numeral: true,
			numeralThousandsGroupStyle: 'thousand',
			numeralDecimalScale: 0,
			numeralDecimalMark: decimalSeparator,
			delimiter: thousandSeparator
		});		
	};
	
	return cleave.getRawValue();
};


var parseFormattedNumber = function (input) {
    if (typeof window.thousandSeparator === "undefined") {
        window.thousandSeparator = ",";
    };

    if (typeof window.decimalSeparator === "undefined") {
        window.decimalSeparator = ".";
    };

    var result = input.split(thousandSeparator).join("");
    result = result.split(decimalSeparator).join(".");
    return result;
};

var getFormattedNumber = function (input, isInteger) {
    if (typeof window.currencyDecimalPlaces === "undefined") {
        window.currencyDecimalPlaces = 2;
    };

    if (typeof window.thousandSeparator === "undefined") {
        window.thousandSeparator = ",";
    };

    if (typeof window.decimalSeparator === "undefined") {
        window.decimalSeparator = ".";
    };

    var decimalPlaces = currencyDecimalPlaces;

    if (isInteger) {
        decimalPlaces = 0;
    };

    return $.number(input, decimalPlaces, decimalSeparator, thousandSeparator);
};


function getFormattedCurrency(input){
    return meta.CurrencySymbol + getFormattedNumber(input);
};


stringFormat = function () {
    var s = arguments[0];

    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    };

    return s;
};

String.prototype.toFormattedDate = function () {
    if (isNullOrWhiteSpace(this)) {
        return "";
    };

    return new Date(this).toString(window.shortDateFormat);
};

function converToUTC(date) {
    return new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds());
};

String.prototype.toMoment = function () {
    if (isNullOrWhiteSpace(this)) {
        return "";
    };

    var d = converToUTC(new Date(this));

    return window.moment(d).fromNow();
};

String.prototype.toTime = function () {
    function padded(num, size) {
        var s = size - num.toString().length + 1;
        return Array(+(s > 0 && s)).join("0") + num;
    };

    if (isNullOrWhiteSpace(this)) {
        return "";
    };

    var val = this;

    if (val.indexOf("Z", val.length - 1) === -1) {
        val += "Z";
    };

    var d = new Date(val);

    return padded(d.getUTCHours(), 2) + ":" + padded(d.getUTCMinutes(), 2);
};

String.prototype.toFormattedHours = function () {
    if (isNullOrWhiteSpace(this)) {
        return "";
    };

    if (!window.i18n.NHours) {
        return this;
    };


    var val = stringFormat(window.i18n.NHours, this);
    return val;
};

String.prototype.toFormattedMinutes = function () {
    if (isNullOrWhiteSpace(this)) {
        return "";
    };

    if (!window.i18n.NMinutes) {
        return this;
    };


    var val = stringFormat(window.i18n.NMinutes, this);
    return val;
};

$(document).ready(function () {
    //setRegionalFormat();
});