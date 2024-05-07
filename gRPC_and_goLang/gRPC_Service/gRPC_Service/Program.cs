using System;
using System.Threading.Tasks;
using Grpc.Core;
using Info; // Import the generated C# code
using Google.Protobuf;


class Program
{
    static async Task Main(string[] args)
    {
        /*
        // Set up a channel to connect to the gRPC server
        var channel = new Channel("localhost:8080", ChannelCredentials.Insecure);

        // Create a client for the PplManagement service
        var client = new PplManagement.PplManagementClient(channel);

        try
        {
            // Create a PersonInfo request
            var request = new PersonInfo
            {
                Name = "John Doe",
                //Num = 123,
                Email = "john.doe@example.com" // Include the email field
            };

            // Call the CreatePerson method
            var response = await client.CreatePersonAsync(request);

            // Display the response
            Console.WriteLine($"Response from CreatePerson: ID: {response.Id}, Company: {response.Company}, Name: {response.Name}, Email: {response.Email}");
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"RPC Error: {ex.Status.Detail}");
        }
        // Shutdown the channel
        await channel.ShutdownAsync();
        */


        // Set up a channel to connect to the gRPC server
        var channel = new Channel("localhost:8080", ChannelCredentials.Insecure);

        // Create a client for the PplManagement service
        var client = new PplManagement.PplManagementClient(channel);

        try
        {
            // Create a PersonInfo request
            var request = new PersonInfo
            {
                Name = "John Doe",
                //Num = 123,
                Email = "john.doe@example.com" // Include the email field
            };

            // Call the CreatePerson method
            var response = await client.CreatePersonAsync(request);

            // Serialize the response message to a byte array
            byte[] responseBytes = response.ToByteArray();


            // Convert the Protobuf message to a string representation
            string messageString = response.ToString();

            // Print the RAW PROTOBUF message AS a HEX STRING
            //Console.WriteLine("Raw Protobuf Message:");
            //Console.WriteLine(BitConverter.ToString(responseBytes).Replace("-", " "));

            // Alternatively, you can print the raw Protobuf message as a BASE64-ENCODED STRING
            //Console.WriteLine("Raw Protobuf Message (Base64):");
            //Console.WriteLine(Convert.ToBase64String(responseBytes));

            // Print the Protobuf message as TEXT
            Console.WriteLine("Protobuf Message as Text:");
            Console.WriteLine(messageString);
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"RPC Error: {ex.Status.Detail}");
        }
         



    }
}
