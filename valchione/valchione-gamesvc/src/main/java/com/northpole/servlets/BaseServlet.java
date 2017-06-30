package com.northpole.servlets;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.log4j.Logger;

import com.northpole.CoreController;
import com.northpole.CoreControllerImpl;
import com.northpole.constants.LoggerConstants;
import com.northpole.controllers.JsonController;
import com.northpole.dto.Dto;

public abstract class BaseServlet<T extends Dto> extends HttpServlet {
	private static final long serialVersionUID = 1L;
	protected Logger syslog;
	protected CoreController coreController;
	
    /**
     * @see HttpServlet#HttpServlet()
     */
    public BaseServlet() {
        super();
        coreController = new CoreControllerImpl();
		syslog = Logger.getLogger(LoggerConstants.SYS);
    }

    /**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request,response);
	}
	
	
	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		syslog.debug(this.getClass().getSimpleName() +" - Start");

		T dto = processParams(request);
		
		response.setContentType("application/json");
		
		if (dto==null)
			response.sendError(400);
		else{
			PrintWriter out = response.getWriter();
			
			out.print(JsonController.toJsonString(dto));
			out.flush();
		}
		
		syslog.debug(this.getClass().getSimpleName() +" - End");

	}
	
	protected abstract T processParams(HttpServletRequest request);
	
}
