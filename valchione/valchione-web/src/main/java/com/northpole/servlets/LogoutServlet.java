package com.northpole.servlets;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.log4j.Logger;

import com.northpole.constants.LoggerConstants;
import com.northpole.dto.PlayerDto;

/**
 * Servlet implementation class LogoutServlet
 */
@WebServlet("/logout")
public class LogoutServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private Logger syslog; 
    /**
     * @see HttpServlet#HttpServlet()
     */
    public LogoutServlet() {
    	super();
        syslog = Logger.getLogger(LoggerConstants.SYS);
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request,response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		syslog.debug("LogoutServlet - Start");
		HttpSession session = request.getSession();
		PlayerDto user = (PlayerDto) session.getAttribute("user");
		
		if (user!=null){
			session.removeAttribute("user");	
			session.invalidate();	
			syslog.info(user.getUsername()+" has sucessfully logged out!");
		}
		RequestDispatcher rd = request.getRequestDispatcher("index.jsp");
		rd.forward(request, response);
		
		syslog.debug("LogoutServlet - End");
	}

}
