import { useState } from "react";
import { StoryRow } from "./StoryRow";

type CollectionCardProps = {
    collection: Collection;
}

async function deleteCollectionAsync(id: number): Promise<void> {

    const res = await fetch(`https://localhost:7177/collection/${id}`,
        { method: 'DELETE' });

    if (!res.ok) {
        console.log(res);
        throw new Error('could not delete user from backend');
    }
}

export function CollectionCard(props: CollectionCardProps) {
    const [isCollapsed, setIsCollapsed] = useState<boolean>(true);
    const collection = props.collection;

    const handleDelete = async () => {
        try {
            await deleteCollectionAsync(props.collection.id!);
        } catch (error) {
            console.log(error);
        }
    };

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
                            <StoryRow story={story} />
                        </div>
                    ))}
                    {!collection.stories || collection.stories.length === 0 && 'No stories yet'}
                </>}

                <div className="button-container">
                    <button onClick={handleDelete}>Delete</button>
                    <button onClick={() => setIsCollapsed(!isCollapsed)}>{isCollapsed ? 'Expand' : 'Collapse'}</button>
                    <button>New Story</button>
                </div>
            </div>

        </div>
    </>
}