﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models.SolvroCity;
using System.IO;
using Solvro_city.Models.Responses;

namespace Solvro_city.Services
{
    /// <summary>
    /// Class that handles generating Solvro city graph structure, allows also for finding path between two nodes in Solvro city
    /// </summary>
    public class SolvroCityGraph : IPathFinding
    {
        /// <summary>
        /// Instance to this class
        /// </summary>
        //static public SolvroCityGraph Instance { get; private set; }
        //List<SolvroCityLink> links { get; set; }

        /// <summary>
        /// List of nodes that creates graph structure
        /// </summary>
        List<SolvroCityGraphNode> Nodes { get; set; }

        /// <summary>
        /// Should graph be created as directed
        /// </summary>
        bool Directed { get; set; }

        /// <summary>
        /// List of nodes with basic data
        /// </summary>
        public List<SolvroCityNode> Stops { 
            get {
                List<SolvroCityNode> nodes = new List<SolvroCityNode>();
                foreach(SolvroCityGraphNode node in Nodes)
                {
                    nodes.Add(new SolvroCityNode(node));
                }
                return nodes;
            } 
        }

        /// <summary>
        /// Prevent creating instances of this class
        /// </summary>
        public SolvroCityGraph() { }


        /// <summary>
        /// Init this class, create graph structure
        /// </summary>
        public void InitGraph()
        {
            SolvroCityData scd = ReadJson();
            CreateGraph(scd);
        }

        /// <summary>
        /// Read data about city from json file 
        /// </summary>
        /// <returns>Data from json file as object</returns>
        SolvroCityData ReadJson()
        {
            if (!File.Exists(Consts.SOLVRO_CITY_JSON_PATH))
                throw new ApplicationException("SOLVRO CITY JSON DATA not provided");

            SolvroCityData SolvroCity = JsonConvert.DeserializeObject<SolvroCityData>(File.ReadAllText(Consts.SOLVRO_CITY_JSON_PATH));

            if(SolvroCity == null)
                throw new ApplicationException("Bad SOLVRO CITY JSON DATA provided");
            return SolvroCity;
        }       

        /// <summary>
        /// Create graph structure
        /// </summary>
        /// <param name="solvroCity">Data that should be used to create graph</param>
        void CreateGraph(SolvroCityData solvroCity)
        {
            Nodes = new List<SolvroCityGraphNode>();
            Directed = solvroCity.directed;
            foreach (SolvroCityNode node in solvroCity.nodes)
            {
                Nodes.Add(new SolvroCityGraphNode(node));
            }
            foreach (SolvroCityLink link in solvroCity.links)
            {
                SolvroCityGraphNode sourceNode = Nodes.Find((node) => node.id == link.source);
                SolvroCityGraphNode destinationNode = Nodes.Find((node) => node.id == link.target);
           
                sourceNode.Links.Add(new SolvroCityGraphLink(link, sourceNode, destinationNode));
                destinationNode.Links.Add(new SolvroCityGraphLink(link, sourceNode, destinationNode, true, Directed ? false : true));
            }
        }


        /// <summary>
        /// Find path between two stops using graph structure
        /// </summary>
        /// <param name="source">Node name where path should start</param>
        /// <param name="destination">Node name where path should end</param>
        /// <returns>Path response: List of nodes for found path and length of path</returns>
        public PathResponse FindPath(string source, string destination)
        {
            SolvroCityGraphNode sourceNode = Nodes.Find((node) => node.stop_name == source); //first node
            SolvroCityGraphNode destinationNode = Nodes.Find((node) => node.stop_name == destination); //last node

            if(sourceNode == null || destinationNode == null) // check if nodes exists before attempting to find path
                return new PathResponse();

            List<SolvroCityGraphNode> nodesCpy = new List<SolvroCityGraphNode>(Nodes); // create copy of nodes on which we can operate
            List<SolvroCityGraphNode> nodesChecked = new List<SolvroCityGraphNode>(); // create empty list for visited nodes
            for (int i = 0; i < nodesCpy.Count; i++) // init weigth of nodes
            {
                nodesCpy[i].weightSum = uint.MaxValue;
                nodesCpy[i].prevNode = null;
            }
            sourceNode.weightSum = 0;
            while (nodesCpy.Count > 0) // proceed with algorithm
            {
                SolvroCityGraphNode minNode = null;
                foreach (SolvroCityGraphNode node in nodesCpy)
                {
                    if (minNode == null || minNode.weightSum > node.weightSum)
                        minNode = node;
                }
                nodesChecked.Add(minNode);
                nodesCpy.RemoveAll((node) => node.id == minNode.id);             
                for (int i = 0; i < minNode.Links.Count; i++)
                {
                    if (minNode.Links[i].Available)
                    {
                        SolvroCityGraphNode neighbor = minNode.Links[i].TargetNode;
                        if(minNode.weightSum != uint.MaxValue && neighbor.weightSum > minNode.weightSum + minNode.Links[i].distance)
                        {
                            neighbor.weightSum = minNode.weightSum + minNode.Links[i].distance;
                            neighbor.prevNode = minNode;
                        }
                    }               
                }
            }
            //best path have been found, proceed to generating "nice" data    
            destinationNode = nodesChecked.Find((node) => node == destinationNode);
            PathResponse pathResponse = new PathResponse() { distance = destinationNode.weightSum }; 
            List<SolvroCityNode> foundNodes = new List<SolvroCityNode>();
            while(destinationNode.prevNode != null) // follow path from target to source (backwards)
            {
                foundNodes.Add(new SolvroCityNode() { id = destinationNode.id, stop_name = destinationNode.stop_name });                     
                destinationNode = destinationNode.prevNode;
            }
            if(destinationNode != sourceNode)
            {
                pathResponse = new PathResponse();
            }
            else
            {
                foundNodes.Add(new SolvroCityNode() { id = destinationNode.id, stop_name = destinationNode.stop_name });
                foundNodes.Reverse(); //path is reversed so we need to call reverse to have it in correct order
                pathResponse.stops = foundNodes;
            }                      
            return pathResponse;
        }
    }
}
