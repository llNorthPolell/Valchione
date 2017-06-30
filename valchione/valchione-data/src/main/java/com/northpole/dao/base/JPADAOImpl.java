package com.northpole.dao.base;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceException;
import javax.persistence.Query;

import com.northpole.dao.enums.WriteAction;
import com.northpole.dao.enums.queries.Queries;
import com.northpole.entity.IStorable;

public abstract class JPADAOImpl <T extends IStorable, Q extends Queries> implements IStorage<T, Q>{
	
	private Class<T> entityType;
	
	protected JPADAOImpl(Class <T> entityType){
		super();
		this.entityType = entityType;
	}
	
	
	public T write(WriteAction writeAction, T entity){
		EntityManager em= createEntityManager();
		T involvedEntity = null;
		em.getTransaction().begin();
		
		switch(writeAction){
		case CREATE:
			em.persist(entity);
			involvedEntity = entity;
			break;
		case UPDATE:
			involvedEntity = em.merge(entity);
			break;
			
		case DELETE:
			involvedEntity = em.merge(entity);
			em.remove(involvedEntity);
			break;
		}
		
		em.getTransaction().commit();
		em.close();	
		
		return involvedEntity;
	}
	
	public List<T> read(Q query, Object...args){
		NamedQueryNamesDto namedQueryNames = query.getNamedQueryNames();
		String[] params = namedQueryNames.getParams();
		
		if (args.length!=params.length)
			return null;
		
		EntityManager em = createEntityManager();
		Query namedQuery = em.createNamedQuery(namedQueryNames.getQueryName(), entityType);
		
		for(int i = 0; i < params.length; i++)
			namedQuery.setParameter(params[i], args[i]);
		
		List<T> resultList = namedQuery.getResultList();
		//em.close();
		return resultList;
	}
	
	public T getById(Long id) {
		EntityManager em = DbConnectionManager.getInstance().createEntityManager();
		T entity = em.find(entityType,  id);
		return entity;
	}
	
	
	private EntityManager createEntityManager(){
		EntityManager em = null;
		try{
			em = DbConnectionManager.getInstance().createEntityManager();
		}
		catch(PersistenceException e){
			System.exit(-1);
		}
		
		return em;
	}
}
