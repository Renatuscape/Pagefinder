import { useEffect, useState } from "react";
import { CollectionCard } from "./CollectionCard";

type PortfolioProps = {
    user: User | null
}

async function fetchCollectionsAsync(id: number | undefined): Promise<Collection[]> {

    if (id !== undefined){
        const response = await fetch(`https://localhost:7177/User/${id}/collections/`);

        try {
            const resObject = await response.json();

            console.log(resObject);

            return resObject;
        }
        catch (error) {
            console.log(error);
            return [];
        }        
    }
    else{
        return [];
    }

}
export function LibraryCard(props: PortfolioProps) {
    const [isCollapsed, setIsCollapsed] = useState<boolean>(false);
    const [collections, setCollections] = useState<Collection[]>([]);

    useEffect(() => {
        fetchCollectionsAsync(props.user?.id).then(collections => setCollections(collections));
    }, [props.user?.id])   


    return <>
        <div className="card" style={{ gridArea: 'portfolio' }}>
            <h2>Your Library</h2>
            {props.user === null && <>
                <p>Please log in to see your portfolio.</p>
            </>}
            {props.user != null && <>
                {isCollapsed && <p>Expand to show all your collections.</p>}
                {!isCollapsed && <>
                    <button onClick={() => setIsCollapsed(!isCollapsed)}>{isCollapsed ? 'Expand' : 'Collapse'}</button>
                    <div className="library-cards">
                        {collections.map(collection => (
                            <div key={collection.id}>
                                <CollectionCard collection={collection} />
                            </div>
                        ))}
                    </div>
                </>}
                <button onClick={() => setIsCollapsed(!isCollapsed)}>{isCollapsed ? 'Expand' : 'Collapse'}</button>
            </>}
        </div>
    </>
}