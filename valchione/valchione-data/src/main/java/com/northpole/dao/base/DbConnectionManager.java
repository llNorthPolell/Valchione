package com.northpole.dao.base;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class DbConnectionManager {
	private static EntityManagerFactory emf;
	
	private static void init(){
		if (emf ==null)
			emf= Persistence.createEntityManagerFactory("Valchione");
	}

	public static EntityManagerFactory getInstance(){
		if (emf==null)
			init();
		
		return emf;
	}
	
	public static void close(){
		if (emf!=null && emf.isOpen())
			emf.close();
	}
}
