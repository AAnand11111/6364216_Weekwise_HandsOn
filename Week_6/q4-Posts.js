import React from 'react';

class Posts extends React.Component {
    // Initialize the component state in the constructor [cite: 51]
    constructor(props){
        super(props);
        this.state = {
            posts: [],
            error: null
        };
    }

    // Method to fetch data from the API [cite: 52]
    loadPosts() {
        fetch('https://jsonplaceholder.typicode.com/posts') // [cite: 53]
            .then(response => response.json())
            .then(data => {
                this.setState({ posts: data });
            })
            .catch(error => {
                this.setState({ error: error.message });
            });
    }

    // Call loadPosts() after the component mounts [cite: 55]
    componentDidMount() {
        this.loadPosts();
    }

    // Handle any errors that occur in child components [cite: 59]
    componentDidCatch(error, info) {
        this.setState({ error: error.message });
        alert("An error occurred: " + error.message);
    }

    // Render the list of posts [cite: 57]
    render() {
        const { posts, error } = this.state;

        if (error) {
            return <div>Error: {error}</div>;
        }

        return (
            <div>
                <h1>Blog Posts</h1>
                {posts.map(post => (
                    <div key={post.id} style={{ borderBottom: '1px solid #ccc', marginBottom: '20px', paddingBottom: '10px' }}>
                        <h2>{post.title}</h2>
                        <p>{post.body}</p>
                    </div>
                ))}
            </div>
        );
    }
}

export default Posts;