package com.northpole;

import org.apache.log4j.Logger;

import com.northpole.constants.LoggerConstants;

public class BaseController {
	protected Logger syslog;
	
	public BaseController(){
		super();
		syslog = Logger.getLogger(LoggerConstants.SYS);
	}
}
