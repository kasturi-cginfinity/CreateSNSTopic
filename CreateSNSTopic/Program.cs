namespace CreateSNSTopicExample
{
    using System;
    using System.Threading.Tasks;
    using Amazon.SimpleNotificationService;
    using Amazon.SimpleNotificationService.Model;
    using Amazon.Runtime;
 
    /// <summary>
    /// This example shows how to use Amazon Simple Notification Service
    /// (Amazon SNS) to add a new Amazon SNS topic. The example was created
    /// using the AWS SDK for .NET version 3.7 and .NET Core 5.0.
    /// </summary>
    public class CreateSNSTopic
    {
        private const string AccessKey = "AKIAZOVM3S6TFOYOYKJM";
        private const string Secret = "2GZuMyX06/lCeukHqRzmqUhTp2BU7+yN/nsVT5Ra";
        public static async Task Main()
        {
            string topicName = "ExampleSNSTopic";
            BasicAWSCredentials credentials = new BasicAWSCredentials(AccessKey, Secret);
            IAmazonSimpleNotificationService client = new AmazonSimpleNotificationServiceClient(credentials, Amazon.RegionEndpoint.APSouth1);

            var topicArn = await CreateSNSTopicAsync(client, topicName);
            Console.WriteLine($"New topic ARN: {topicArn}");
        }

  

        /// <summary>
        /// Creates a new SNS topic using the supplied topic name.
        /// </summary>
       ///<param name="client">The initialized SNS client object used to
        /// create the new topic.</param>
        /// <param name="topicName">A string representing the topic name.</param>
        /// <returns>The Amazon Resource Name (ARN) of the created topic.</returns>
        public static async Task<string> CreateSNSTopicAsync(IAmazonSimpleNotificationService client, string topicName)
        {
            var request = new CreateTopicRequest
            {
                Name = topicName,
            };

            var response = await client.CreateTopicAsync(request);

            return response.TopicArn;
        }
    }
}