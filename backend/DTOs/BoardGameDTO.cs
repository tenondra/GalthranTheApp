using System.Text.Json.Serialization;
using Google.Protobuf.Collections;
using Qdrant.Client.Grpc;

namespace backend.DTOs;

public record BoardGameDTO
{
    public Guid Id { get; set; }
    
    [JsonPropertyName("group_id")]
    public Guid GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("previous_id")]
    public Guid PreviousChunkId { get; set; }
    
    [JsonPropertyName("following_id")]
    public Guid FollowingChunkId { get; set; }
    
    [JsonPropertyName("related_image_id")]
    public Guid RelatedImageId { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    public static MapField<string, Value> ToPayloadStructure(BoardGameDTO dto) => new()
    {
        ["group_id"] = dto.GroupId.ToString(),
        ["name"] = dto.Name,
        ["previous_id"] = dto.PreviousChunkId.ToString(),
        ["following_id"] = dto.FollowingChunkId.ToString(),
        ["related_image_id"] = dto.RelatedImageId.ToString(),
        ["text"] = dto.Text
    };
}
