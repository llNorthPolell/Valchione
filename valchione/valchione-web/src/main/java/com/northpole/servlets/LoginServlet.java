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

import com.northpole.CoreControllerImpl;
import com.northpole.constants.LoggerConstants;
import com.northpole.dto.PlayerDto;

/**
 * Servlet implementation class LoginServlet
 */
@WebServlet("/login")
public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private CoreControllerImpl coreController;

	private Logger syslog;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public LoginServlet() {
		super();
		coreController = new CoreControllerImpl();
		syslog = Logger.getLogger(LoggerConstants.SYS);
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		syslog.debug("LoginServlet - Start");

		String username = request.getParameter("username");
		String password = request.getParameter("password");

		PlayerDto playerDto = coreController.login(username, password);

		HttpSession session = request.getSession();
		session.setAttribute("user", playerDto);

		if (playerDto == null) {
			session.setAttribute("msg", "Invalid Username/Password...");
			response.sendRedirect("/LandOfSnow-Server/index.jsp?page=login");
			syslog.debug("LoginServlet - End");
			return;
		}
		RequestDispatcher rd = request.getRequestDispatcher("index.jsp");
		rd.forward(request, response);

		syslog.debug("LoginServlet - End");

	}

}
