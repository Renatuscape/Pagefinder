import { useState } from "react";
import { StoryRow } from "./StoryRow";

type CollectionCardProps = {
    collection: Collection;
}

export function CollectionCard(props: CollectionCardProps) {
    const [isCollapsed, setIsCollapsed] = useState<boolean>(false);
    const collection = props.collection;
    return <>
        <div className="collection-thumbnail">
            <div style={{ borderRadius: 0, width: '100%', height: 150, backgroundColor: '#66a2ad', backgroundImage: `url(${collection.imageUrl ? collection.imageUrl : '/public/images/icon_collection_default.png'})` }}>
            </div>
            <div className="collection-thumbnail-inner">
                <h2>{collection.name}</h2>
                <p>{collection.description}</p>
                {!isCollapsed && <>
                {collection.stories && collection.stories?.map(story => (
                    <div key={story.id}>
                        <StoryRow story={story}/>
                    </div>
                ))}
                {!collection.stories || collection.stories.length === 0 && 'No stories yet'}                
                </>}

                <div className="button-container">
                    <button>Edit</button>
                    <button onClick={()=> setIsCollapsed(!isCollapsed)}>{isCollapsed ? 'Expand' : 'Collapse'}</button>
                    <button>New Story</button>
                </div>
            </div>

        </div>
    </>
}