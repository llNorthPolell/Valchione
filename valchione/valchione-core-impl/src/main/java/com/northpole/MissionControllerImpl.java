package com.northpole;

import java.util.List;

import com.northpole.dao.MissionDao;
import com.northpole.dao.impl.MissionDaoImpl;
import com.northpole.dto.MissionDto;

public class MissionControllerImpl extends BaseController implements MissionController {
	private MissionDao missionDao;
	
	public MissionControllerImpl(){
		super();
		missionDao = new MissionDaoImpl();
	}
	
	public MissionDto getById(Long id) {
		syslog.debug("MissionControllerImpl.getById - Start");
		syslog.debug("MissionControllerImpl.getById - End");
		return new MissionDto(missionDao.getById(id));
	}

	public int getMaxStoryProgress() {
		syslog.debug("MissionControllerImpl.getMaxStoryProgress - Start");
		syslog.debug("MissionControllerImpl.getMaxStoryProgress - End");
		return missionDao.getMaxStoryProgress();
	}
	
	public List<String> getAllStoryQuestNames(int chapter){
		syslog.debug("MissionControllerImpl.getAllStoryQuestNames - Start");
		syslog.debug("MissionControllerImpl.getAllStoryQuestNames - End");
		return missionDao.getAllStoryQuestNames(chapter);
	}

}
