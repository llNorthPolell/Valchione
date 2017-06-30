var minPasswordLength=8;
var maxPasswordLength=16;

function isInt(value){
	var vRegExp= /^[1-9]?[0-9]+$/;
	
	return (RegExp(vRegExp).test(value));
}


function isLessThanMinimum(value, minval){
	if (minval=="" || !isInt(minval))
		return false;
	
	return (new Number(minval)>new Number(value));
}

function isMatch(value1, value2){
	return value1==value2;
}

function isLengthInBounds(value, minlength, maxlength){
	return (value.length>=minlength && value.length<=maxlength);	
}

function isEmail(value){
	var vRegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
	
	return (RegExp(vRegExp).test(value));
}

function isInList(value, list){
	var listItem= $(list).find("option[value='"+value+"']");
	
	return (listItem !=null && listItem.length>0);
}

function isMoney(value){
	var vRegExp = /^[1-9]?[0-9]+\.[0-9]{2}$/;
	
	return (RegExp(vRegExp).test(value));
}

function limitpriceValidationMsg(input){
	var value= $(".limitprice").val();
	var message='';
	if (!isMoney(value))
		message='Must be a Monetary Value';
	
	input.setCustomValidity(message);
}

function stoppriceValidationMsg(input){
	var value= $(".stopprice").val();
	var message='';
	if (!isMoney(value))
		message='Must be a Monetary Value';
	
	input.setCustomValidity(message);
}

function companyListValidationMsg(input,listid){
	var value= $("#companylisttxtbx").val();
	var list= $("#companylist");
	var message='';
	if(!isInList(value,list))
		message+='Company Does Not Exist |';
		
	input.setCustomValidity(message);
}

function emailValidationMsg(input){
	var value= $(".email").val();
	var message ='';
	if (!isEmail(value))
		message +='Invalid Email |';
	input.setCustomValidity(message);
}

function passwordValidationMsg(input){
	var value= $(".password").val();
	var message ='';
	if (!isLengthInBounds(value, minPasswordLength,maxPasswordLength))
		message += 'Password must be 8 to 16 characters long |';
	
	input.setCustomValidity(message);
}

function passwordConfValidationMsg(input){
	var value= $(".password").val();
	var value2= $(".password-confirm").val();
	
	var message ='';
	if (!isMatch(value, value2))
		message += 'Passwords Do Not Match |';
	
	input.setCustomValidity(message);
}

function minsharesValidationMsg(input){
	var value= $(".minshares").val();
	var sharesvalue= $(".shares").val();
	
	var message ='';
	if (!isInt(value))
		message+='Not an Integer |';
	if (isLessThanMinimum(sharesvalue, value))
		message+='Minimum shares is higher than number of shares |';
	
	input.setCustomValidity(message);
}

function sharesValidationMsg(input){
	var value= $(".shares").val();
	var minval= $(".minshares").val();
	
	
	var message ='';
	if (!isInt(value))
		message+='Not an Integer |';
	if (isLessThanMinimum(value, minval))
		message+='Less than Minimum |';
	
	input.setCustomValidity(message);
}

