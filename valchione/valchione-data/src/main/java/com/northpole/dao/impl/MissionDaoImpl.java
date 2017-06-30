package com.northpole.dao.impl;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import com.northpole.dao.MissionDao;

public class MissionDaoImpl implements MissionDao {
	private final String mapFilePath = "C:\\Users\\Lenovo\\Documents\\Valchione\\valchione-maps\\";
	
	
	public String getById(Long id){
		String output = "";
		
		if (id == null)
			return null;
		
		String strId;
		
		if (id < 10) 
			strId = "0" + id.toString();
		else
			strId= id.toString();
		
		
		try {
			Scanner reader  = new Scanner(new File(mapFilePath+strId+".json"));

			String line = "";
			while(reader.hasNext()){
				line = reader.nextLine();
				output +=line;
			}
			if (reader != null)
				reader.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		output = output.replaceAll("\\s+",""); 
		return output;
	}


	public int getMaxStoryProgress() {
		File mapFolder = new File(mapFilePath);
		
		return mapFolder.list().length;
	}
	
	public List<String> getAllStoryQuestNames(int chapter){
		File mapFolder = new File(mapFilePath);
		String[] storyQuestNames = mapFolder.list();
		List<String> mapNames = new ArrayList<String>();
		
		if (chapter == 0)
			for (String mapFileName : storyQuestNames)
				mapNames.add(mapFileName.replace(".json", ""));
	
		//TODO: Get Story Quests with Pagination
		return mapNames;
			
	}
}
