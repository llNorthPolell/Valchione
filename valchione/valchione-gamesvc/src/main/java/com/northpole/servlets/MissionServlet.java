package com.northpole.servlets;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.northpole.dto.MissionDto;

/**
 * Servlet implementation class LoadMissionServlet
 */
@WebServlet("/loadMission")
public class MissionServlet extends BaseServlet<MissionDto> {
	private static final long serialVersionUID = 1L;
	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public MissionServlet() {
		super();
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		syslog.debug("MissionServlet - Start");

		MissionDto missionDto = processParams(request);
		
		response.setContentType("application/json");
		if (missionDto == null) {
			response.sendError(404);
		} else {
			PrintWriter out = response.getWriter();
			out.print(missionDto.getMissionJson());
			out.flush();
		}

		syslog.debug("MissionServlet - End");
	}

	@Override
	protected MissionDto processParams(HttpServletRequest request) {
		String missionIdStr = request.getParameter("missionId");


		if (missionIdStr == null) 
			return null;
		
		Long missionId = Long.parseLong(missionIdStr);

		return coreController.getMission(missionId);
	}

}
