import { useState } from "react";
import { CreateStory } from "./CreateStory";
import { CreateCollection } from "./CreateCollection";

type EditorCardProps = {
    user: User | null;
    story: Story | null;
    collection: Collection | null;
}

export function EditorCard(props: EditorCardProps) {
    const [createStory, setCreateStory] = useState<Boolean>(false);
    const [createCollection, setCreateCollection] = useState<Boolean>(false);
    const [editStory, setEditStory] = useState<Boolean>(false);
    const [editCollection, setEditCollection] = useState<Boolean>(false);

    const [storyId, setStoryId] = useState<number | null>(null);
    const [collectionId, setCollectionId] = useState<number | null>(null);

    const clickCreateStory = () => {
        setCreateStory(true);
        setEditStory(false);
        setCreateCollection(false);
    }

    const clickCreateCollection = () => {
        setCreateStory(false);
        setEditStory(false);
        setCreateCollection(true);
        setEditCollection(false);
    }

    const clickEditStory = (storyId: number) => {
        setCreateStory(false);
        setEditStory(true);
        setCreateCollection(false);
        setEditCollection(false);
        setStoryId(storyId);
    }

    const clickEditCollection = (collectionId: number) => {
        setCreateStory(false);
        setEditStory(true);
        setCreateCollection(false);
        setEditCollection(true);
        setCollectionId(collectionId);
    }

    const clickCancel = () => {
        setCreateStory(false);
        setEditStory(false);
        setCreateCollection(false);
        setEditCollection(false);
    }

    return <>
        <div className="card" style={{ gridArea: 'editor', backgroundColor: '#bfe4e6' }}>
            {props.user ?
                <>
                    <h2>Editor</h2>
                    {createStory && <>
                        <CreateStory editStory={clickEditStory} userId={props.user?.id} />
                    </>}
                    {editStory && <>
                        <p>Edit story component here</p>
                    </>}
                    {createCollection && <>
                        <CreateCollection userId={props.user?.id} editCollection={clickEditCollection} />
                    </>}
                    {editCollection && <>
                        <p>Edit collection component here</p>
                    </>}
                </>
                :
                <div className="card"><h2>Log in to begin creating!</h2></div>
            }

            <div className="button-container">
                <button onClick={clickCreateCollection}>Create Collection</button><button onClick={clickCreateStory}>Create Story</button><button>Edit Story</button><button onClick={clickCancel}>Cancel</button>
            </div>
        </div>
    </>
}