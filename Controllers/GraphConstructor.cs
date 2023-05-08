using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tflzone1.Models;

namespace tflzone1.Controllers
{
    static class GraphConstructor
    {
        public static Graph graph; //= new Graph();

        public static void ConstructGraph()
        {
            graph = new Graph();

            // Bakerloo Station Vertices
            graph.AddVertex("bakerloo: paddington");
            graph.AddVertex("bakerloo: edgware road");
            graph.AddVertex("bakerloo: maryleborne");
            graph.AddVertex("bakerloo: baker street");
            graph.AddVertex("bakerloo: regent's park");
            graph.AddVertex("bakerloo: oxford circus");
            graph.AddVertex("bakerloo: picadilly circus");
            graph.AddVertex("bakerloo: charing cross");
            graph.AddVertex("bakerloo: embarkment");
            graph.AddVertex("bakerloo: waterloo");
            graph.AddVertex("bakerloo: labert North");
            graph.AddVertex("bakerloo: elephant and castle");

            // Central Station Vertices
            graph.AddVertex("central: notting hill gate");
            graph.AddVertex("central: queensway");
            graph.AddVertex("central: lancaster gate");
            graph.AddVertex("central: marble arch");
            graph.AddVertex("central: bond street");
            graph.AddVertex("central: oxford circus");
            graph.AddVertex("central: tottenham court road");
            graph.AddVertex("central: holborn");
            graph.AddVertex("central: chancery lane");
            graph.AddVertex("central: st. paul’s");
            graph.AddVertex("central: bank");
            graph.AddVertex("central: liverpool street");

            // Circle Station Vertices
            graph.AddVertex("circle: edgware road");
            graph.AddVertex("circle: paddington");
            graph.AddVertex("circle: bayswater");
            graph.AddVertex("circle: notting hill gate");
            graph.AddVertex("circle: high street kensington");
            graph.AddVertex("circle: gloucester road");
            graph.AddVertex("circle: south kensington");
            graph.AddVertex("circle: sloane square");
            graph.AddVertex("circle: victoria");
            graph.AddVertex("circle: st. james’s park");
            graph.AddVertex("circle: westminster");
            graph.AddVertex("circle: embankment");
            graph.AddVertex("circle: temple");
            graph.AddVertex("circle: blackfriars");
            graph.AddVertex("circle: mansion house");
            graph.AddVertex("circle: cannon street");
            graph.AddVertex("circle: monument");
            graph.AddVertex("circle: tower hill");
            graph.AddVertex("circle: aldgate");
            graph.AddVertex("circle: liverpool street");
            graph.AddVertex("circle: moorgate");
            graph.AddVertex("circle: barbican");
            graph.AddVertex("circle: farringdon");
            graph.AddVertex("circle: king’s cross st. pancras");
            graph.AddVertex("circle: euston square");
            graph.AddVertex("circle: great portland street");
            graph.AddVertex("circle: baker street");

            // District Station Vertices
            graph.AddVertex("district: edgware road");
            graph.AddVertex("district: paddington");
            graph.AddVertex("district: bayswater");
            graph.AddVertex("district: notting hill gate");
            graph.AddVertex("district: high street kensington");
            graph.AddVertex("district: earls court");
            graph.AddVertex("district: gloucester road");
            graph.AddVertex("district: south kensington");
            graph.AddVertex("district: sloane square");
            graph.AddVertex("district: victoria");
            graph.AddVertex("district: st. james's park");
            graph.AddVertex("district: westminster");
            graph.AddVertex("district: embankment");
            graph.AddVertex("district: temple");
            graph.AddVertex("district: blackfriars");
            graph.AddVertex("district: mansion house");
            graph.AddVertex("district: cannon street");
            graph.AddVertex("district: monument");
            graph.AddVertex("district: tower hill");
            graph.AddVertex("district: aldgate east");

            // Hammersmith & City Station Vertices
            graph.AddVertex("hammersmith & city: edgware road");
            graph.AddVertex("hammersmith & city: baker street");
            graph.AddVertex("hammersmith & city: great portland street");
            graph.AddVertex("hammersmith & city: euston square");
            graph.AddVertex("hammersmith & city: king’s cross st. pancras");
            graph.AddVertex("hammersmith & city: farringdon");
            graph.AddVertex("hammersmith & city: barbican");
            graph.AddVertex("hammersmith & city: moorgate");
            graph.AddVertex("hammersmith & city: liverpool street");
            graph.AddVertex("hammersmith & city: aldgate east");

            // Jubilee Station Vertices
            graph.AddVertex("jubilee: baker street");
            graph.AddVertex("jubilee: bond street");
            graph.AddVertex("jubilee: green park");
            graph.AddVertex("jubilee: westminster");
            graph.AddVertex("jubilee: waterloo");
            graph.AddVertex("jubilee: southwark");
            graph.AddVertex("jubilee: london bridge");

            // Metropilitan Station Vertices
            graph.AddVertex("metropolitan: aldgate");
            graph.AddVertex("metropolitan: liverpool street");
            graph.AddVertex("metropolitan: moorgate");
            graph.AddVertex("metropolitan: barbican");
            graph.AddVertex("metropolitan: farringdon");
            graph.AddVertex("metropolitan: kings cross st pancras");
            graph.AddVertex("metropolitan: euston square");
            graph.AddVertex("metropolitan: great portland street");
            graph.AddVertex("metropolitan: baker street");

            // Northern Station Vertices
            graph.AddVertex("northern: euston");
            graph.AddVertex("northern: warren street");
            graph.AddVertex("northern: goodge street");
            graph.AddVertex("northern: tottenham court road");
            graph.AddVertex("northern: leicester square");
            graph.AddVertex("northern: charing cross");
            graph.AddVertex("northern: embankment");
            graph.AddVertex("northern: elephant and castle");
            graph.AddVertex("northern: borough");
            graph.AddVertex("northern: london bridge");
            graph.AddVertex("northern: bank");
            graph.AddVertex("northern: moorgate");
            graph.AddVertex("northern: old street");
            graph.AddVertex("northern: angel");
            graph.AddVertex("northern: king's cross st.pancras");

            // Piccadilly Station Vertices
            graph.AddVertex("piccadilly: king's cross st.pancras");
            graph.AddVertex("piccadilly: russell square");
            graph.AddVertex("piccadilly: holborn");
            graph.AddVertex("piccadilly: covent garden");
            graph.AddVertex("piccadilly: leicester square");
            graph.AddVertex("piccadilly: piccadilly circus");
            graph.AddVertex("piccadilly: green park");
            graph.AddVertex("piccadilly: hyde park corner");
            graph.AddVertex("piccadilly: knightsbridge");
            graph.AddVertex("piccadilly: south kensington");
            graph.AddVertex("piccadilly: gloucester road");
            graph.AddVertex("piccadilly: earl’s court");

            // Victoria Station Vertices
            graph.AddVertex("victoria: euston");
            graph.AddVertex("victoria: warren street");
            graph.AddVertex("victoria: oxford circus");
            graph.AddVertex("victoria: green park");
            graph.AddVertex("victoria: victoria");
            graph.AddVertex("victoria: pimlico");
            graph.AddVertex("victoria: vauxhall");

            // Waterloo & City Station Vertices
            graph.AddVertex("waterloo & city: waterloo");
            graph.AddVertex("waterloo & city: bank");

            // Bakerloo Station Edges
            graph.AddEdge(new Vertex("bakerloo: paddington"), new Vertex("bakerloo: edgware road"), 11);
            graph.AddEdge(new Vertex("bakerloo: edgware road"), new Vertex("bakerloo: maryleborne"), 7);
            graph.AddEdge(new Vertex("bakerloo: maryleborne"), new Vertex("bakerloo: baker street"), 6);
            graph.AddEdge(new Vertex("bakerloo: baker street"), new Vertex("bakerloo: regent's park"), 10);
            graph.AddEdge(new Vertex("bakerloo: regent's park"), new Vertex("bakerloo: oxford circus"), 15);
            graph.AddEdge(new Vertex("bakerloo: oxford circus"), new Vertex("bakerloo: picadilly circus"), 12);
            graph.AddEdge(new Vertex("bakerloo: picadilly circus"), new Vertex("bakerloo: charing cross"), 11);
            graph.AddEdge(new Vertex("bakerloo: charing cross"), new Vertex("bakerloo: embarkment"), 3);
            graph.AddEdge(new Vertex("bakerloo: embarkment"), new Vertex("bakerloo: waterloo"), 6);
            graph.AddEdge(new Vertex("bakerloo: waterloo"), new Vertex("bakerloo: labert North"), 9);
            graph.AddEdge(new Vertex("bakerloo: labert North"), new Vertex("bakerloo: elephant and castle"), 18);

            // Central Station Edges
            graph.AddEdge(new Vertex("central: notting hill gate"), new Vertex("central: queensway"), 8);
            graph.AddEdge(new Vertex("central: queensway"), new Vertex("central: lancaster gate"), 10);
            graph.AddEdge(new Vertex("central: lancaster gate"), new Vertex("central: marble arch"), 15);
            graph.AddEdge(new Vertex("central: marble arch"), new Vertex("central: bond street"), 7);
            graph.AddEdge(new Vertex("central: bond street"), new Vertex("central: oxford circus"), 7);
            graph.AddEdge(new Vertex("central: oxford circus"), new Vertex("central: tottenham court road"), 9);
            graph.AddEdge(new Vertex("central: tottenham court road"), new Vertex("central: holborn"), 10);
            graph.AddEdge(new Vertex("central: holborn"), new Vertex("central: chancery lane"), 8);
            graph.AddEdge(new Vertex("central: chancery lane"), new Vertex("central: st. paul’s"), 14);
            graph.AddEdge(new Vertex("central: st. paul’s"), new Vertex("central: bank"), 9);
            graph.AddEdge(new Vertex("central: bank"), new Vertex("central: liverpool street"), 10);

            // Circle Station Edges
            graph.AddEdge(new Vertex("circle: edgware road"), new Vertex("circle: paddington"), 10);
            graph.AddEdge(new Vertex("circle: paddington"), new Vertex("circle: bayswater"), 17);
            graph.AddEdge(new Vertex("circle: bayswater"), new Vertex("circle: notting hill gate"), 10);
            graph.AddEdge(new Vertex("circle: notting hill gate"), new Vertex("circle: high street kensington"), 13);
            graph.AddEdge(new Vertex("circle: high street kensington"), new Vertex("circle: gloucester road"), 18);
            graph.AddEdge(new Vertex("circle: gloucester road"), new Vertex("circle: south kensington"), 8);
            graph.AddEdge(new Vertex("circle: south kensington"), new Vertex("circle: sloane square"), 17);
            graph.AddEdge(new Vertex("circle: sloane square"), new Vertex("circle: victoria"), 13);
            graph.AddEdge(new Vertex("circle: victoria"), new Vertex("circle: st. james’s park"), 11);
            graph.AddEdge(new Vertex("circle: st. james’s park"), new Vertex("circle: westminster"), 11);
            graph.AddEdge(new Vertex("circle: westminster"), new Vertex("circle: embankment"), 10);
            graph.AddEdge(new Vertex("circle: embankment"), new Vertex("circle: temple"), 9);
            graph.AddEdge(new Vertex("circle: temple"), new Vertex("circle: blackfriars"), 10);
            graph.AddEdge(new Vertex("circle: blackfriars"), new Vertex("circle: mansion house"), 10);
            graph.AddEdge(new Vertex("circle: mansion house"), new Vertex("circle: cannon street"), 4);
            graph.AddEdge(new Vertex("circle: cannon street"), new Vertex("circle: monument"), 5);
            graph.AddEdge(new Vertex("circle: monument"), new Vertex("circle: tower hill"), 10);
            graph.AddEdge(new Vertex("circle: tower hill"), new Vertex("circle: aldgate"), 9);
            graph.AddEdge(new Vertex("circle: aldgate"), new Vertex("circle: liverpool street"), 9);
            graph.AddEdge(new Vertex("circle: liverpool street"), new Vertex("circle: moorgate"), 6);
            graph.AddEdge(new Vertex("circle: moorgate"), new Vertex("circle: barbican"), 10);
            graph.AddEdge(new Vertex("circle: barbican"), new Vertex("circle: farringdon"), 8);
            graph.AddEdge(new Vertex("circle: farringdon"), new Vertex("circle: king’s cross st. pancras"), 26);
            graph.AddEdge(new Vertex("circle: king’s cross st. pancras"), new Vertex("circle: euston square"), 15);
            graph.AddEdge(new Vertex("circle: euston square"), new Vertex("circle: great portland street"), 10);
            graph.AddEdge(new Vertex("circle: great portland street"), new Vertex("circle: baker street"), 13);
            graph.AddEdge(new Vertex("circle: baker street"), new Vertex("circle: edgware road"), 10);

            // District Station Edges
            graph.AddEdge(new Vertex("district: edgware road"), new Vertex("district: paddington"), 10);
            graph.AddEdge(new Vertex("district: paddington"), new Vertex("district: bayswater"), 17);
            graph.AddEdge(new Vertex("district: bayswater"), new Vertex("district: notting hill gate"), 10);
            graph.AddEdge(new Vertex("district: notting hill gate"), new Vertex("district: high street kensington"), 13);
            graph.AddEdge(new Vertex("district: high street kensington"), new Vertex("district: earls court"), 18);
            graph.AddEdge(new Vertex("district: earls court"), new Vertex("district: gloucester road"), 12);
            graph.AddEdge(new Vertex("district: gloucester road"), new Vertex("district: south kensington"), 8);
            graph.AddEdge(new Vertex("district: south kensington"), new Vertex("district: sloane square"), 17);
            graph.AddEdge(new Vertex("district: sloane square"), new Vertex("district: victoria"), 13);
            graph.AddEdge(new Vertex("district: victoria"), new Vertex("district: st. james's park"), 11);
            graph.AddEdge(new Vertex("district: st. james's park"), new Vertex("district: westminster"), 11);
            graph.AddEdge(new Vertex("district: westminster"), new Vertex("district: embankment"), 10);
            graph.AddEdge(new Vertex("district: embankment"), new Vertex("district: temple"), 9);
            graph.AddEdge(new Vertex("district: temple"), new Vertex("district: blackfriars"), 10);
            graph.AddEdge(new Vertex("district: blackfriars"), new Vertex("district: mansion house"), 10);
            graph.AddEdge(new Vertex("district: mansion house"), new Vertex("district: cannon street"), 4);
            graph.AddEdge(new Vertex("district: cannon street"), new Vertex("district: monument"), 5);
            graph.AddEdge(new Vertex("district: monument"), new Vertex("district: tower hill"), 10);
            graph.AddEdge(new Vertex("district: tower hill"), new Vertex("district: aldgate east"), 10);

            // Hammersmith & city Station Edges
            graph.AddEdge(new Vertex("hammersmith & city: edgware road"), new Vertex("hammersmith & city: baker street"), 10);
            graph.AddEdge(new Vertex("hammersmith & city: baker street"), new Vertex("hammersmith & city: great portland street"), 13);
            graph.AddEdge(new Vertex("hammersmith & city: great portland street"), new Vertex("hammersmith & city: euston square"), 10);
            graph.AddEdge(new Vertex("hammersmith & city: euston square"), new Vertex("hammersmith & city: king’s cross st. pancras"), 15);
            graph.AddEdge(new Vertex("hammersmith & city: king’s cross st. pancras"), new Vertex("hammersmith & city: farringdon"), 26);
            graph.AddEdge(new Vertex("hammersmith & city: farringdon"), new Vertex("hammersmith & city: barbican"), 8);
            graph.AddEdge(new Vertex("hammersmith & city: barbican"), new Vertex("hammersmith & city: moorgate"), 10);
            graph.AddEdge(new Vertex("hammersmith & city: moorgate"), new Vertex("hammersmith & city: liverpool street"), 6);
            graph.AddEdge(new Vertex("hammersmith & city: liverpool street"), new Vertex("hammersmith & city: aldgate east"), 11);

            // Jubilee Station Edges
            graph.AddEdge(new Vertex("jubilee: baker street"), new Vertex("jubilee: bond street"), 16);
            graph.AddEdge(new Vertex("jubilee: bond street"), new Vertex("jubilee: green park"), 14);
            graph.AddEdge(new Vertex("jubilee: green park"), new Vertex("jubilee: westminster"), 21);
            graph.AddEdge(new Vertex("jubilee: westminster"), new Vertex("jubilee: waterloo"), 17);
            graph.AddEdge(new Vertex("jubilee: waterloo"), new Vertex("jubilee: southwark"), 8);
            graph.AddEdge(new Vertex("jubilee: southwark"), new Vertex("jubilee: london bridge"), 19);

            // Metropolitan Station Edges
            graph.AddEdge(new Vertex("metropolitan: aldgate"), new Vertex("metropolitan: liverpool street"), 9);
            graph.AddEdge(new Vertex("metropolitan: liverpool street"), new Vertex("metropolitan: moorgate"), 6);
            graph.AddEdge(new Vertex("metropolitan: moorgate"), new Vertex("metropolitan: barbican"), 10);
            graph.AddEdge(new Vertex("metropolitan: barbican"), new Vertex("metropolitan: farringdon"), 8);
            graph.AddEdge(new Vertex("metropolitan: farringdon"), new Vertex("metropolitan: kings cross st pancras"), 26);
            graph.AddEdge(new Vertex("metropolitan: kings cross st pancras"), new Vertex("metropolitan: euston square"), 15);
            graph.AddEdge(new Vertex("metropolitan: euston square"), new Vertex("metropolitan: great portland street"), 10);
            graph.AddEdge(new Vertex("metropolitan: great portland street"), new Vertex("metropolitan: baker street"), 13);
            
            // Northern Station Edges
            graph.AddEdge(new Vertex("northern: euston"), new Vertex("northern: warren street"), 9);
            graph.AddEdge(new Vertex("northern: warren street"), new Vertex("northern: goodge street"), 7);
            graph.AddEdge(new Vertex("northern: goodge street"), new Vertex("northern: tottenham court road"), 7);
            graph.AddEdge(new Vertex("northern: tottenham court road"), new Vertex("northern: leicester square"), 8);
            graph.AddEdge(new Vertex("northern: leicester square"), new Vertex("northern: charing cross"), 7);
            graph.AddEdge(new Vertex("northern: charing cross"), new Vertex("northern: embankment"), 3);
            graph.AddEdge(new Vertex("northern: embankment"), new Vertex("northern: elephant and castle"), 6);
            graph.AddEdge(new Vertex("northern: elephant and castle"), new Vertex("northern: borough"), 13);
            graph.AddEdge(new Vertex("northern: borough"), new Vertex("northern: london bridge"), 9);
            graph.AddEdge(new Vertex("northern: london bridge"), new Vertex("northern: bank"), 6);
            graph.AddEdge(new Vertex("northern: bank"), new Vertex("northern: moorgate"), 9);
            graph.AddEdge(new Vertex("northern: moorgate"), new Vertex("northern: old street"), 9);
            graph.AddEdge(new Vertex("northern: old street"), new Vertex("northern: angel"), 20);
            graph.AddEdge(new Vertex("northern: angel"), new Vertex("northern: king's cross st.pancras"), 16);
            graph.AddEdge(new Vertex("northern: king's cross st.pancras"), new Vertex("northern: euston"), 12);

            // Piccadilly Station Edges
            graph.AddEdge(new Vertex("piccadilly: king's cross st.pancras"), new Vertex("piccadilly: russell square"), 14);
            graph.AddEdge(new Vertex("piccadilly: russell square"), new Vertex("piccadilly: holborn"), 9);
            graph.AddEdge(new Vertex("piccadilly: holborn"), new Vertex("piccadilly: covent garden"), 8);
            graph.AddEdge(new Vertex("piccadilly: covent garden"), new Vertex("piccadilly: leicester square"), 4);
            graph.AddEdge(new Vertex("piccadilly: leicester square"), new Vertex("piccadilly: piccadilly circus"), 6);
            graph.AddEdge(new Vertex("piccadilly: piccadilly circus"), new Vertex("piccadilly: green park"), 8);
            graph.AddEdge(new Vertex("piccadilly: green park"), new Vertex("piccadilly: hyde park corner"), 12);
            graph.AddEdge(new Vertex("piccadilly: hyde park corner"), new Vertex("piccadilly: knightsbridge"), 7);
            graph.AddEdge(new Vertex("piccadilly: knightsbridge"), new Vertex("piccadilly: south kensington"), 17);
            graph.AddEdge(new Vertex("piccadilly: south kensington"), new Vertex("piccadilly: gloucester road"), 8);
            graph.AddEdge(new Vertex("piccadilly: gloucester road"), new Vertex("piccadilly: earl’s court"), 12);

            // Victoria Station Edges
            graph.AddEdge(new Vertex("victoria: euston"), new Vertex("victoria: warren street"), 9);
            graph.AddEdge(new Vertex("victoria: warren street"), new Vertex("victoria: oxford circus"), 18);
            graph.AddEdge(new Vertex("victoria: oxford circus"), new Vertex("victoria: green park"), 15);
            graph.AddEdge(new Vertex("victoria: green park"), new Vertex("victoria: victoria"), 19);
            graph.AddEdge(new Vertex("victoria: victoria"), new Vertex("victoria: pimlico"), 12);
            graph.AddEdge(new Vertex("victoria: pimlico"), new Vertex("victoria: vauxhall"), 18);

            // Waterloo & City Station Vertices
            graph.AddEdge(new Vertex("waterloo & city: waterloo"), new Vertex("waterloo & city: bank"), 33);
        }
    }
}