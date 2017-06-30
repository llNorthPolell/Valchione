package com.northpole;

import com.northpole.controllers.MissionDataExtractor;

public class TiledExtractor {
	
	public static void main(String[] args) {
		String fileName = "02.json";
		String inputJsonFilePath = "C:\\Users\\Lenovo\\Documents\\Valchione\\valchione-originalmaps\\"+fileName;
		String outputJsonFilePath = "C:\\Users\\Lenovo\\Documents\\Valchione\\valchione-maps\\"+fileName;

		System.out.println("Extraction Initiated!");
		MissionDataExtractor.extractJsonFromFile(inputJsonFilePath);
		MissionDataExtractor.exportToJsonFile(outputJsonFilePath);
		System.out.println("Extraction Complete!");
	}

}
