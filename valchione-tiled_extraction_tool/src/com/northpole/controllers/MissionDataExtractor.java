package com.northpole.controllers;

import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import org.codehaus.jackson.JsonNode;

import com.northpole.dto.MissionDto;

public class MissionDataExtractor {
	// Outputs
	private static MissionDto output;

	// Buffer
	private static int numOfPlayers;
	private static int height;
	private static int width;
	private static String missionObjectives;
	private static Map<Integer, String> playingFieldStrings = new HashMap<Integer, String>();
	private static List<String> structureStrings = new ArrayList<String>();
	private static Map<Integer, String> tilesUsed;

	private static void extractMissionData(String jsonFilePath) {
		JsonNode root = JsonController.getJsonNodeObj(jsonFilePath);

		// Get Number of Players
		numOfPlayers = Integer.parseInt(root.get("properties").get("NumOfPlayers").toString().replace("\"", ""));

		// Get Map Dimensions
		height = Integer.parseInt(root.get("height").toString());
		width = Integer.parseInt(root.get("width").toString());

		// Get Mission Objective
		missionObjectives = root.get("properties").get("MissionObjectives").toString();

		// Layer Information
		JsonNode layersNode = root.get("layers");
		int numOfLayers = layersNode.size();
		JsonNode[] layer = new JsonNode[numOfLayers];
		playingFieldStrings = new HashMap<Integer, String>();
		structureStrings = new ArrayList<String>();

		int currAltitude = 0;
		for (int i = 0; i < numOfLayers; i++) {
			layer[i] = layersNode.get(i);

			String layerName = layer[i].get("name").toString();
			if (layerName.contains("Field")) {
				currAltitude = Integer
						.parseInt(layerName.substring(layerName.indexOf("[") + 1, layerName.indexOf("]")));
				String playingFieldString = layer[i].get("data").toString();
				playingFieldStrings.put(currAltitude, playingFieldString.substring(1, playingFieldString.length() - 1));
				currAltitude++;
			} else if (layerName.contains("Structures")) {
				JsonNode structuresNode = layer[i].get("objects");
				int numOfStructures = structuresNode.size();

				for (int j = 0; j < numOfStructures; j++) {
					structureStrings.add(structuresNode.get(j).toString());
				}
			}
		}

		// Tiles
		tilesUsed = new HashMap<Integer, String>();
		JsonNode tileset = root.get("tilesets");

		for (JsonNode tile : tileset)
			tilesUsed.put(Integer.parseInt(tile.get("firstgid").toString()), tile.get("name").toString());
	}

	private static void packageData() {
		output = new MissionDto();
		output.setNumOfPlayers(numOfPlayers);
		output.setHeight(height);
		output.setWidth(width);
		output.setMissionObjectives(missionObjectives);

		String altitudes = "";
		String tiles = "";
		for (Entry<Integer, String> e : playingFieldStrings.entrySet()) {
			if (altitudes.isEmpty())
				altitudes = e.getKey().toString();
			else
				altitudes += "," + e.getKey();

			if (tiles.isEmpty())
				tiles = TileMapDecoder.decode(e.getValue(), width, height).toString().trim();
			else
				tiles += "+" + TileMapDecoder.decode(e.getValue(), width, height).toString().trim();
		}
		output.setTiles(tiles);

		String gids = "";
		String tileNames = "";

		for (Entry<Integer, String> e : tilesUsed.entrySet()) {
			String tileName = e.getValue();
			tileName = tileName.replace("\"", "");

			if (gids.isEmpty())
				gids = e.getKey().toString();
			else
				gids += "," + e.getKey();

			if (tileNames.isEmpty())
				tileNames = tileName;
			else {
				tileNames += "," + tileName;
			}
		}

		output.setGids(gids);
		output.setTileNames(tileNames);

		System.out.println("Tiles:" + output.getTiles());
	}

	public static void exportToJsonFile(String jsonFilePath) {
		PrintWriter out;
		try {
			out = new PrintWriter(jsonFilePath);
			JsonController.writeJsonToFile(output, out);
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}

	}

	public static MissionDto extractJsonFromFile(String inputJsonFilePath) {
		System.out.println("Extraction Initiated!");
		extractMissionData(inputJsonFilePath);
		packageData();
		System.out.println("Extraction Complete!");
		return output;
	}

	

}
