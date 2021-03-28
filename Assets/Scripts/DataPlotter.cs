using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataPlotter : MonoBehaviour
{
    // Name of the input file, no extension
    public string[] inputfiles;

    //Getting values for dashboard
    public string followerCount;
    public string hashtagCount;
    public string tweetLength;
    public string username;

    // List for holding data from CSV reader
    private List<Dictionary<string, object>> pointList;

    // Indices for columns to be assigned
    public int userNameColumn = 2;

    public int columnX = 1;
    public int columnY = 4;
    public int columnZ = 3;

    // Full column names
    public string post_user;
    public string x_twt_text;
    public string y_fol_count;
    public string z_hshtg_count;

    //Store values of x, y, z to get max and min for normalization
    private List<string> tweetText_List = new List<string>();
    private List<float> x_values = new List<float>();
    private List<float> y_values = new List<float>();
    private List<float> z_values = new List<float>();
    private List<string> usernames = new List<string>();

    // The prefab for the data points to be instantiated
    public GameObject PointPrefab;

    // The prefab for the data points that will be instantiated
    public GameObject PointHolder;

    public float plotScale = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Set pointlist to results of function Reader with argument inputfile
        //pointList = CSVReader.Read(inputfiles[0]);


        //Log to console
        //Debug.Log(pointList);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            if (PointHolder.transform.childCount > 0)
            {
                for (int i = 0; i <= PointHolder.transform.childCount; i++)

                {
                    GameObject child = PointHolder.transform.GetChild(i).gameObject;
                    Destroy(child);
                }
            }

            
            //Read from one of the CSV files randomly
            System.Random random = new System.Random();
            int r = random.Next(0, inputfiles.Length);
            //Debug.Log(r);
            pointList = CSVReader.Read(inputfiles[r]);


            //Get list of columns that exist in the CSV file
            List<string> columnList = new List<string>(pointList[1].Keys);
            //Debug.Log("columnList" + string.Join("\t",columnList));

            // Print number of keys (using .count)
            //Debug.Log("There are " + columnList.Count + " columns in CSV");

            //foreach (string key in columnList)
                //Debug.Log("Column name is " + key);

            // Assign column name from columnList to Name variables
            post_user = columnList[userNameColumn];
            x_twt_text = columnList[columnX];
            y_fol_count = columnList[columnY];
            z_hshtg_count = columnList[columnZ];

            //Loop through Pointlist and get values for each column in a list
            for (var i = 0; i < pointList.Count; i++)
            {
                //Get List of tweet texts
                tweetText_List.Add(pointList[i][x_twt_text].ToString());
                
                //Get List of tweet text Length
                x_values.Add(pointList[i][x_twt_text].ToString().Length);
                //Get LIst of Follower counts
                y_values.Add(System.Convert.ToSingle(pointList[i][y_fol_count]));
                //Get List of Hashtag counts
                z_values.Add(pointList[i][z_hshtg_count].ToString().Split(new char[] { ',' }).Length);
                //Get list of usernames form CSV file
                usernames.Add(pointList[i][post_user].ToString());

                // Get maxes of each axis
                float xMax = FindMaxValue(x_values);
                float yMax = FindMaxValue(y_values);
                float zMax = FindMaxValue(z_values);

                // Get minimums of each axis
                float xMin = FindMinValue(x_values);
                float yMin = FindMinValue(y_values);
                float zMin = FindMinValue(z_values);

                

                // Get value in poinList at ith "row", in "column" Name, normalize
                float x =
                (x_values[i] - xMin) / (xMax - xMin);

                float y =
                (y_values[i] - yMin) / (yMax - yMin);

                float z =
                (z_values[i] - zMin) / (zMax - zMin);
                

                //Absolut Values 
                // Get value in poinList at ith "row", in "column" Name
                //int x = pointList[i][xName];
                //float y = pointList[i][yName];
                //float z = pointList[i][zName];


                
                //instantiate the prefab with coordinates defined above
                //Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);

                // Instantiate as gameobject variable so that it can be manipulated within loop
                GameObject dataPoint = Instantiate(
                    PointPrefab,
                    new Vector3(x, y, z) * plotScale,
                    Quaternion.identity);

                // Make dataPoint child of PointHolder object 
                dataPoint.transform.parent = PointHolder.transform;

                // Assigns original values to dataPointName
                string dataPointName = pointList[i][x_twt_text].ToString();
                //Export actual values of Follower-count, Tweet length and hashtag counts to Inspector


                // Assigns name to the prefab
                dataPoint.transform.name = dataPointName;

                // Gets material color and sets it to a new RGBA color we define
                dataPoint.GetComponent<Renderer>().material.color =
                new Color(x, y, z, 1.0f);
                
            }
            Debug.Log("tweetText_list Length: " + tweetText_List.Count);
            Debug.Log("Text Lenght list Length: " + x_values.Count);
            Debug.Log("Follower count list Length: " + y_values.Count);
            Debug.Log("Hashtage count list Length: " + z_values.Count);
            //Debug.Log("X_Values: " + x_values.Count);
            //Debug.Log("Y_Values: " + y_values.Count);
            //Debug.Log("Z_Values: " + z_values.Count);

        }
    }

    private float FindMaxValue(List<float> values)
    {
        //set initial value to first value
        float maxValue = 0.0f;

        //Loop through Dictionary, overwrite existing maxValue if new value is larger
        for (var i = 0; i < values.Count; i++)
        {
            if (maxValue < values[i])
                maxValue = values[i];
        }

        //Spit out the max value
        return maxValue;
    }

    private float FindMinValue(List<float> values)
    {

        float minValue = 0.0f;

        //Loop through Dictionary, overwrite existing minValue if new value is smaller
        for (var i = 0; i < values.Count; i++)
        {
            if (values[i] < minValue)
                minValue = values[i];
        }

        return minValue;
    }

    public List<string> GetValues(string tweetText)
    {
        List<string> result = new List<string>(4);
        //get the tweetText and find its index int tweet list
        Debug.Log("tweetText from GetValues :::::::::::::::::::::::::::::::"+tweetText);
        var index = tweetText_List.IndexOf(tweetText);
        Debug.Log("Index of selected text: " + index);
        //use the index to find username, tweetlength, hashtag count and follower count of that tweet
        followerCount = y_values[index].ToString();
        hashtagCount = z_values[index].ToString();
        tweetLength = x_values[index].ToString();
        username = usernames[index] ;
        //return list of found values in string format
        result.Add(username);
        result.Add(followerCount);
        result.Add(tweetLength);
        result.Add(hashtagCount);

        Debug.Log(String.Join(", ", result));
        return result;
    }
}

