package com.northpole.servlets;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;

import com.northpole.dto.UnitDtoList;

/**
 * Servlet implementation class UnitInfoServlet
 */
@WebServlet("/loadUnitInfo")
public class LoadUnitInfoServlet extends BaseServlet<UnitDtoList> {
	private static final long serialVersionUID = 1L;
	
    /**
     * @see HttpServlet#HttpServlet()
     */
    public LoadUnitInfoServlet() {
        super();
    }
    
	@Override
	protected UnitDtoList processParams(HttpServletRequest request) {
		return coreController.loadUnitInfo();
	}

}


