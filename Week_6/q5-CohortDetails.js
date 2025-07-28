import React from 'react';
import styles from './CohortDetails.module.css'; // Import the CSS module

// This component receives cohort data as a prop
const CohortDetails = ({ cohort }) => {

    // Define inline style for h3 based on cohort status
    // Green for "Ongoing", Blue for everything else [cite: 68]
    const headerStyle = {
        color: cohort.status === 'Ongoing' ? 'green' : 'blue'
    };

    return (
        // Apply the 'box' class from the CSS module [cite: 67]
        <div className={styles.box}>
            <h3 style={headerStyle}>{cohort.name}</h3>
            <dl>
                <dt>Started On</dt>
                <dd>{cohort.startedOn}</dd>

                <dt>Current Status</dt>
                <dd>{cohort.status}</dd>

                <dt>Coach</dt>
                <dd>{cohort.coach}</dd>

                <dt>Trainer</dt>
                <dd>{cohort.trainer}</dd>
            </dl>
        </div>
    );
};

export default CohortDetails;