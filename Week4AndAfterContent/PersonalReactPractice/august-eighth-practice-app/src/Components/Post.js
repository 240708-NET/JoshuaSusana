import React from "react";
import { useParams } from "react-router-dom";

const Post = () => {
  const { id } = useParams();
  return <h1>Post Details for Post ID: {id}</h1>;
};

export default Post;
