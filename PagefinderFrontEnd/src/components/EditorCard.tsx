import { useState } from "react";
import { CreateStory } from "./CreateStory";
import { CreateCollection } from "./CreateCollection";
import { EditStory } from "./EditStory";
import { EditCollection } from "./EditCollection";

type EditorCardProps = {
    user: User | null;
    story: Story | null;
    collection: Collection | null;
    updateCollectionInUser: (updatedCollection: Collection) => void;
}

export function EditorCard(props: EditorCardProps) {
    const [createStory, setCreateStory] = useState<Boolean>(false);
    const [createCollection, setCreateCollection] = useState<Boolean>(false);
    const [editStory, setEditStory] = useState<Boolean>(false);
    const [editCollection, setEditCollection] = useState<Boolean>(false);

    const [storyId, setEditStoryId] = useState<number | null>(null);
    const [collectionId, setEditCollectionId] = useState<number | null>(null);

    const [story, setStory] = useState<Story>({ id: -1, title: 'BadResponse', collectionId: -1 });

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

    const clickEditStory = () => {
        setCreateStory(false);
        setEditStory(true);
        setCreateCollection(false);
        setEditCollection(false);
    }

    const clickEditCollection = () => {
        setCreateStory(false);
        setEditStory(false);
        setCreateCollection(false);
        setEditCollection(true);
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
                        <CreateStory setEditStoryId={setEditStoryId} editStory={clickEditStory} userId={props.user?.id} />
                    </>}
                    {editStory && <>
                        <EditStory closeComponent={clickCancel} user={props.user} storyId={storyId}/>
                    </>}
                    {createCollection && <>
                        <CreateCollection userId={props.user?.id} setEditCollectionId={setEditCollectionId} editCollection={clickEditCollection} />
                    </>}
                    {editCollection && <>
                    <EditCollection user={props.user} closeComponent={clickCancel} collectionId={collectionId} updateCollectionInUser={props.updateCollectionInUser}/>
                    </>}
                </>
                :
                <div className="card"><h2>Log in to begin creating!</h2></div>
            }

            <div className="button-container">
                <button onClick={clickCreateCollection}>Create Collection</button><button onClick={clickEditCollection}>Edit Collection</button><button onClick={clickCreateStory}>Create Story</button><button onClick={clickEditStory}>Edit Story</button><button onClick={clickCancel}>Cancel</button>
            </div>
        </div>
    </>
}