using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models.SolvroCity;
using System.IO;
using Solvro_city.Models.Responses;

namespace Solvro_city
{
    public class SolvroCityGraph
    {
        static public SolvroCityGraph Instance { get; private set; }
        //List<SolvroCityLink> links { get; set; }
        public SolvroCityData SolvroCity { get; private set; }
        List<SolvroCityGraphNode> nodes { get; set; }


        private SolvroCityGraph() { }

        public static void InitGraph()
        {
            if (Instance == null)
            {
                Instance = new SolvroCityGraph();
                Instance.ReadJson();
                Instance.CreateGraph();
            }
        }

        void ReadJson()
        {
            if (!File.Exists(Consts.SOLVRO_CITY_JSON_PATH))
                throw new ApplicationException("SOLVRO CITY JSON DATA not provided");

            SolvroCity = JsonConvert.DeserializeObject<SolvroCityData>(File.ReadAllText(Consts.SOLVRO_CITY_JSON_PATH));

            if(SolvroCity == null)
                throw new ApplicationException("Bad SOLVRO CITY JSON DATA provided");       
        }       
        void CreateGraph()
        {
            nodes = new List<SolvroCityGraphNode>();
            foreach (SolvroCityNode node in SolvroCity.nodes)
            {
                nodes.Add(new SolvroCityGraphNode(node));
            }
            foreach (SolvroCityLink link in SolvroCity.links)
            {
                SolvroCityGraphNode sourceNode = nodes.Find((node) => node.id == link.source);
                SolvroCityGraphNode destinationNode = nodes.Find((node) => node.id == link.target);

                sourceNode.Links.Add(new SolvroCityGraphLink(link, sourceNode, destinationNode));
                destinationNode.Links.Add(new SolvroCityGraphLink(link, sourceNode, destinationNode, true));
            }
        }

        public PathResponse FindPath(string source, string destination)
        {
            SolvroCityGraphNode sourceNode = nodes.Find((node) => node.stop_name == source);
            SolvroCityGraphNode destinationNode = nodes.Find((node) => node.stop_name == destination);

            if(sourceNode == null || destinationNode == null)
                return new PathResponse();

            List<SolvroCityGraphNode> nodesCpy = new List<SolvroCityGraphNode>(nodes);
            List<SolvroCityGraphNode> nodesChecked = new List<SolvroCityGraphNode>();
            nodesChecked.Add(sourceNode);
            nodesCpy.RemoveAll((node) => node.id == sourceNode.id );
            for(int i = 0; i < nodesCpy.Count; i++)
            {
                SolvroCityGraphLink link = nodesCpy[i].Links.Find((node) => node.target == sourceNode.id);
                if (link != null)
                    nodesCpy[i].weightSum = link.distance;
                else
                    nodesCpy[i].weightSum = uint.MaxValue;
            }
            while(nodesChecked.Count != nodes.Count)
            {
                SolvroCityGraphNode minNode = null;
                foreach(SolvroCityGraphNode node in nodesCpy)
                {
                    if (minNode == null || minNode.weightSum > node.weightSum)
                        minNode = node;
                }
                nodesChecked.Add(minNode);
                nodesCpy.RemoveAll((node) => node.id == minNode.id);             
                for (int i = 0; i < nodesCpy.Count; i++)
                {
                    SolvroCityGraphLink solvroCityLink = minNode.Links.Find((node) => node.source == minNode.id && node.target == nodesCpy[i].id);
                    if (solvroCityLink == null)
                        nodesCpy[i].weightSum = nodesCpy[i].weightSum;
                    else
                    {
                        nodesCpy[i].weightSum = Math.Min(nodesCpy[i].weightSum, minNode.weightSum + solvroCityLink.distance);
                    }                   
                }
            }
            destinationNode = nodesChecked.Find((node) => node == destinationNode);
            PathResponse pathResponse = new PathResponse() { distance = destinationNode.weightSum };
            List<SolvroCityNode> foundNodes = new List<SolvroCityNode>();
            while(destinationNode.weightSum != 0)
            {
                foundNodes.Add(new SolvroCityNode() { id = destinationNode.id, stop_name = destinationNode.stop_name });
                SolvroCityGraphNode bestNode = null;
                for(int i = 0; i < destinationNode.Links.Count; i++)
                {
                    if(bestNode == null || destinationNode.Links[i].TargetNode.weightSum < bestNode.weightSum)
                    {
                        bestNode = destinationNode.Links[i].TargetNode;
                    }                        
                }              
                destinationNode = bestNode;
            }
            foundNodes.Add(new SolvroCityNode() { id = destinationNode.id, stop_name = destinationNode.stop_name });
            foundNodes.Reverse();
            pathResponse.stops = foundNodes;
            return pathResponse;
        }
    }
}
